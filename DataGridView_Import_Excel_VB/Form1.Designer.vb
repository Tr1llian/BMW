<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbHeaderYes = New System.Windows.Forms.RadioButton()
        Me.rbHeaderNo = New System.Windows.Forms.RadioButton()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.groupBox1.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.rbHeaderYes)
        Me.groupBox1.Controls.Add(Me.rbHeaderNo)
        Me.groupBox1.Location = New System.Drawing.Point(148, 14)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(98, 33)
        Me.groupBox1.TabIndex = 10
        Me.groupBox1.TabStop = False
        '
        'rbHeaderYes
        '
        Me.rbHeaderYes.AutoSize = True
        Me.rbHeaderYes.Checked = True
        Me.rbHeaderYes.Location = New System.Drawing.Point(6, 11)
        Me.rbHeaderYes.Name = "rbHeaderYes"
        Me.rbHeaderYes.Size = New System.Drawing.Size(43, 17)
        Me.rbHeaderYes.TabIndex = 7
        Me.rbHeaderYes.TabStop = True
        Me.rbHeaderYes.Text = "Yes"
        Me.rbHeaderYes.UseVisualStyleBackColor = True
        '
        'rbHeaderNo
        '
        Me.rbHeaderNo.Location = New System.Drawing.Point(55, 11)
        Me.rbHeaderNo.Name = "rbHeaderNo"
        Me.rbHeaderNo.Size = New System.Drawing.Size(85, 17)
        Me.rbHeaderNo.TabIndex = 6
        Me.rbHeaderNo.Text = "No"
        Me.rbHeaderNo.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(11, 22)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 8
        Me.btnSelect.Text = "Select File"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(103, 27)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(42, 13)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Header"
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(11, 51)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(344, 112)
        Me.dataGridView1.TabIndex = 7
        '
        'OpenFileDialog1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 177)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents rbHeaderYes As System.Windows.Forms.RadioButton
    Private WithEvents rbHeaderNo As System.Windows.Forms.RadioButton
    Private WithEvents btnSelect As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
