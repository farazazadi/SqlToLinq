using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxCore;
using Microsoft.Extensions.DependencyInjection;
using SqlToLinq.Core.Common;
using SqlToLinq.Core.Extensions;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;
using SqlToLinq.Core.Queries;
using SqlToLinq.WinUi.Extensions;

namespace SqlToLinq.WinUi
{
    public partial class MainForm : Form
    {

        private ServiceCollection _serviceCollection;
        private ServiceProvider _serviceProvider;

        private Query _query;

        public MainForm()
        {
            InitializeComponent();

            ConfigureServices();

            ConfigureQueryListContextMenu();

            ConfigureQueryListView();

            PopulateQueryListView();

            highlighter.TextChangedDelayed += HighlighterOnTextChangedDelayed;

        }

        private void ConfigureServices()
        {
            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddDbContext<BikeStoresContext>();
            _serviceCollection.AddTransient<IAdoExecutor, AdoExecutor>();

            _serviceCollection.Scan(scan => scan
                .FromAssemblyOf<Query>()
                .AddClasses(classes => classes.AssignableTo<Query>())
                .AsSelf()
                .WithSingletonLifetime());

            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        private void ConfigureQueryListContextMenu()
        {
            executeAdoToolStripMenuItem.Tag = QueryType.Sql;
            executeAdoToolStripMenuItem.Click += ExecuteToolStripMenuItemsOnClick;

            executeLinqMethodSyntaxToolStripMenuItem.Tag = QueryType.LinqMethodSyntax;
            executeLinqMethodSyntaxToolStripMenuItem.Click += ExecuteToolStripMenuItemsOnClick;

            executeLinqQuerySyntaxToolStripMenuItem.Tag = QueryType.LinqQuerySyntax;
            executeLinqQuerySyntaxToolStripMenuItem.Click += ExecuteToolStripMenuItemsOnClick;
        }

        private void ConfigureQueryListView()
        {
            queryListView.MouseClick += QueryListViewOnMouseClick;
            queryListView.MouseDoubleClick += QueryListViewOnMouseDoubleClick;
        }

        private void ExecuteToolStripMenuItemsOnClick(object sender, EventArgs e)
        {
            if(sender is not ToolStripMenuItem {Tag: QueryType queryType})
                return;

            ExecuteSelectedQuery(queryType);
        }

        private void QueryListViewOnMouseClick(object sender, MouseEventArgs e)
        {
            var mousePos = queryListView.PointToClient(MousePosition);
            var hitTest = queryListView.HitTest(mousePos);

            var typeFullName = hitTest.Item.Name;

            SetSelectedQuery(typeFullName);

            if(e.Button == MouseButtons.Right)
                queryListContextMenu.Show(Cursor.Position);
        }

        private void QueryListViewOnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExecuteSelectedQuery(QueryType.LinqMethodSyntax);
        }

        private void HighlighterOnTextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            if (sender is not FastColoredTextBox fastColoredTextBox)
                return;

            SetMixedStyleSchema(fastColoredTextBox);
        }

        private void PopulateQueryListView()
        {
            var queries = _serviceCollection
                .Where(s => s.ServiceType.IsAssignableTo(typeof(Query)))
                .OrderBy(s=> s.ServiceType.Name)
                .ToList();


            foreach (var service in queries)
                queryListView.Items.Add(service.ServiceType.FullName, 
                    service.ServiceType.Name.SplitCamelCase(), 0);
        }

        private void SetSelectedQuery(string typeFullName)
        {


            var serviceType = _serviceCollection
                .FirstOrDefault(s => s.ServiceType.FullName == typeFullName)?
                .ServiceType;

            var query = _query = (Query)_serviceProvider
                .GetRequiredService(serviceType ?? throw new InvalidOperationException());


            highlighter.Text = query.ToString();
        }

        private void ExecuteSelectedQuery(QueryType queryType)
        {
            try
            {
                var executionResult = queryType switch
                {
                    QueryType.Sql => _query.ExecuteAdoApproach(),
                    QueryType.LinqMethodSyntax => _query.ExecuteLinqMethodSyntaxApproach(),
                    QueryType.LinqQuerySyntax => _query.ExecuteLinqQuerySyntaxApproach(),
                    _ => throw new ArgumentOutOfRangeException(nameof(queryType), queryType, null)
                };

                resultGridView.DataSource = executionResult.Result;

                logHighlighter.Text = executionResult.ToString();

            }
            catch (Exception e)
            {
                resultGridView.DataSource = null;
                logHighlighter.Text = string.Empty;
                logHighlighter.Log(e.Message, FastColoredTextBoxExt.LogType.Error);
            }

        }

        private static void SetMixedStyleSchema(FastColoredTextBox fastColoredTextBox)
        {
            fastColoredTextBox.SyntaxHighlighter.InitStyleSchema(Language.CSharp);
            fastColoredTextBox.SyntaxHighlighter.CSharpSyntaxHighlight(fastColoredTextBox.Range);

            foreach (var r in fastColoredTextBox.GetRanges(@"(?i)------- SQL Query\s+(.+?)\s+----- SQL Query",
                RegexOptions.Singleline | RegexOptions.IgnoreCase))
            {
                r.ClearStyle(StyleIndex.All);
                fastColoredTextBox.SyntaxHighlighter.InitStyleSchema(Language.SQL);
                fastColoredTextBox.SyntaxHighlighter.SQLSyntaxHighlight(r);
            }
        }


    }
}
