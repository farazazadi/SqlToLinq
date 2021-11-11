
namespace SqlToLinq.WinUi
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.queryListView = new System.Windows.Forms.ListView();
            this.queryImageList = new System.Windows.Forms.ImageList(this.components);
            this.queryListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.executeAdoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.executeLinqMethodSyntaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeLinqQuerySyntaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.highlighter = new FastColoredTextBoxCore.FastColoredTextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.resultGridView = new System.Windows.Forms.DataGridView();
            this.logHighlighter = new FastColoredTextBoxCore.FastColoredTextBox();
            this.queryListContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.highlighter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logHighlighter)).BeginInit();
            this.SuspendLayout();
            // 
            // queryListView
            // 
            this.queryListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.queryListView.FullRowSelect = true;
            this.queryListView.GridLines = true;
            this.queryListView.HideSelection = false;
            this.queryListView.LargeImageList = this.queryImageList;
            this.queryListView.Location = new System.Drawing.Point(2, 2);
            this.queryListView.Name = "queryListView";
            this.queryListView.Size = new System.Drawing.Size(237, 481);
            this.queryListView.SmallImageList = this.queryImageList;
            this.queryListView.TabIndex = 0;
            this.queryListView.UseCompatibleStateImageBehavior = false;
            this.queryListView.View = System.Windows.Forms.View.List;
            // 
            // queryImageList
            // 
            this.queryImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.queryImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("queryImageList.ImageStream")));
            this.queryImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.queryImageList.Images.SetKeyName(0, "dot2.png");
            // 
            // queryListContextMenu
            // 
            this.queryListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeAdoToolStripMenuItem,
            this.toolStripSeparator2,
            this.executeLinqMethodSyntaxToolStripMenuItem,
            this.executeLinqQuerySyntaxToolStripMenuItem});
            this.queryListContextMenu.Name = "queryListContextMenu";
            this.queryListContextMenu.Size = new System.Drawing.Size(233, 76);
            // 
            // executeAdoToolStripMenuItem
            // 
            this.executeAdoToolStripMenuItem.Image = global::SqlToLinq.WinUi.Properties.Resources.Exec;
            this.executeAdoToolStripMenuItem.Name = "executeAdoToolStripMenuItem";
            this.executeAdoToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.executeAdoToolStripMenuItem.Text = "Execute (SQL - Ado)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            // 
            // executeLinqMethodSyntaxToolStripMenuItem
            // 
            this.executeLinqMethodSyntaxToolStripMenuItem.Image = global::SqlToLinq.WinUi.Properties.Resources.Exec;
            this.executeLinqMethodSyntaxToolStripMenuItem.Name = "executeLinqMethodSyntaxToolStripMenuItem";
            this.executeLinqMethodSyntaxToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.executeLinqMethodSyntaxToolStripMenuItem.Text = "Execute (Linq Method Syntax)";
            // 
            // executeLinqQuerySyntaxToolStripMenuItem
            // 
            this.executeLinqQuerySyntaxToolStripMenuItem.Image = global::SqlToLinq.WinUi.Properties.Resources.Exec;
            this.executeLinqQuerySyntaxToolStripMenuItem.Name = "executeLinqQuerySyntaxToolStripMenuItem";
            this.executeLinqQuerySyntaxToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.executeLinqQuerySyntaxToolStripMenuItem.Text = "Execute (Linq Query Syntax)";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(239, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 481);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // highlighter
            // 
            this.highlighter.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.highlighter.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);\n";
            this.highlighter.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.highlighter.BackBrush = null;
            this.highlighter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highlighter.BracketsHighlightStrategy = FastColoredTextBoxCore.BracketsHighlightStrategy.Strategy2;
            this.highlighter.CharHeight = 15;
            this.highlighter.CharWidth = 7;
            this.highlighter.CurrentLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.highlighter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.highlighter.DefaultMarkerSize = 8;
            this.highlighter.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.highlighter.Dock = System.Windows.Forms.DockStyle.Top;
            this.highlighter.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.highlighter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.highlighter.IsReplaceMode = false;
            this.highlighter.Language = FastColoredTextBoxCore.Language.CSharp;
            this.highlighter.LeftBracket = '(';
            this.highlighter.LeftBracket2 = '{';
            this.highlighter.Location = new System.Drawing.Point(242, 2);
            this.highlighter.Name = "highlighter";
            this.highlighter.Paddings = new System.Windows.Forms.Padding(0);
            this.highlighter.ReadOnly = true;
            this.highlighter.RightBracket = ')';
            this.highlighter.RightBracket2 = '}';
            this.highlighter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.highlighter.ServiceColors = ((FastColoredTextBoxCore.ServiceColors)(resources.GetObject("highlighter.ServiceColors")));
            this.highlighter.ShowFoldingLines = true;
            this.highlighter.Size = new System.Drawing.Size(663, 170);
            this.highlighter.TabIndex = 1;
            this.highlighter.TextAreaBorderColor = System.Drawing.Color.Gray;
            this.highlighter.Zoom = 100;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(242, 172);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(663, 3);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(242, 175);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.resultGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.logHighlighter);
            this.splitContainer1.Size = new System.Drawing.Size(663, 308);
            this.splitContainer1.SplitterDistance = 163;
            this.splitContainer1.TabIndex = 7;
            // 
            // resultGridView
            // 
            this.resultGridView.AllowUserToAddRows = false;
            this.resultGridView.AllowUserToDeleteRows = false;
            this.resultGridView.AllowUserToOrderColumns = true;
            this.resultGridView.AllowUserToResizeRows = false;
            this.resultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.resultGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGridView.Location = new System.Drawing.Point(0, 0);
            this.resultGridView.MultiSelect = false;
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.ReadOnly = true;
            this.resultGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGridView.Size = new System.Drawing.Size(663, 163);
            this.resultGridView.TabIndex = 2;
            // 
            // logHighlighter
            // 
            this.logHighlighter.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.logHighlighter.AutoIndentCharsPatterns = "";
            this.logHighlighter.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.logHighlighter.BackBrush = null;
            this.logHighlighter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logHighlighter.BracketsHighlightStrategy = FastColoredTextBoxCore.BracketsHighlightStrategy.Strategy2;
            this.logHighlighter.CharHeight = 15;
            this.logHighlighter.CharWidth = 7;
            this.logHighlighter.CommentPrefix = "--";
            this.logHighlighter.CurrentLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.logHighlighter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.logHighlighter.DefaultMarkerSize = 8;
            this.logHighlighter.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.logHighlighter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logHighlighter.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logHighlighter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.logHighlighter.IsReplaceMode = false;
            this.logHighlighter.Language = FastColoredTextBoxCore.Language.SQL;
            this.logHighlighter.LeftBracket = '(';
            this.logHighlighter.Location = new System.Drawing.Point(0, 0);
            this.logHighlighter.Name = "logHighlighter";
            this.logHighlighter.Paddings = new System.Windows.Forms.Padding(0);
            this.logHighlighter.ReadOnly = true;
            this.logHighlighter.RightBracket = ')';
            this.logHighlighter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.logHighlighter.ServiceColors = ((FastColoredTextBoxCore.ServiceColors)(resources.GetObject("logHighlighter.ServiceColors")));
            this.logHighlighter.ShowFoldingLines = true;
            this.logHighlighter.Size = new System.Drawing.Size(663, 141);
            this.logHighlighter.TabIndex = 3;
            this.logHighlighter.TextAreaBorderColor = System.Drawing.Color.Gray;
            this.logHighlighter.Zoom = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 485);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.highlighter);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.queryListView);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL To LINQ";
            this.queryListContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.highlighter)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logHighlighter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView queryListView;
        private System.Windows.Forms.Splitter splitter1;
        private FastColoredTextBoxCore.FastColoredTextBox highlighter;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView resultGridView;
        private FastColoredTextBoxCore.FastColoredTextBox logHighlighter;
        private System.Windows.Forms.ImageList queryImageList;
        private System.Windows.Forms.ContextMenuStrip queryListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem executeAdoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeLinqMethodSyntaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeLinqQuerySyntaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

