<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJeu
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlLabyrinthe = New System.Windows.Forms.TableLayoutPanel()
        Me.gpeMove = New System.Windows.Forms.GroupBox()
        Me.btnPasAPas = New System.Windows.Forms.Button()
        Me.btnAuto = New System.Windows.Forms.Button()
        Me.btnNO = New System.Windows.Forms.Button()
        Me.btnO = New System.Windows.Forms.Button()
        Me.btnSO = New System.Windows.Forms.Button()
        Me.btnS = New System.Windows.Forms.Button()
        Me.btnSE = New System.Windows.Forms.Button()
        Me.btnE = New System.Windows.Forms.Button()
        Me.btnNE = New System.Windows.Forms.Button()
        Me.btnN = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblInformations = New System.Windows.Forms.Label()
        Me.timerPas = New System.Windows.Forms.Timer(Me.components)
        Me.timerFantome = New System.Windows.Forms.Timer(Me.components)
        Me.btnFantomes = New System.Windows.Forms.Button()
        Me.chkBloquerFantomes = New System.Windows.Forms.CheckBox()
        Me.gpeMove.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLabyrinthe
        '
        Me.pnlLabyrinthe.AutoSize = True
        Me.pnlLabyrinthe.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.pnlLabyrinthe.ColumnCount = 11
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.pnlLabyrinthe.Location = New System.Drawing.Point(9, 9)
        Me.pnlLabyrinthe.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlLabyrinthe.Name = "pnlLabyrinthe"
        Me.pnlLabyrinthe.RowCount = 11
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLabyrinthe.Size = New System.Drawing.Size(233, 232)
        Me.pnlLabyrinthe.TabIndex = 0
        '
        'gpeMove
        '
        Me.gpeMove.Controls.Add(Me.btnPasAPas)
        Me.gpeMove.Controls.Add(Me.btnAuto)
        Me.gpeMove.Controls.Add(Me.btnNO)
        Me.gpeMove.Controls.Add(Me.btnO)
        Me.gpeMove.Controls.Add(Me.btnSO)
        Me.gpeMove.Controls.Add(Me.btnS)
        Me.gpeMove.Controls.Add(Me.btnSE)
        Me.gpeMove.Controls.Add(Me.btnE)
        Me.gpeMove.Controls.Add(Me.btnNE)
        Me.gpeMove.Controls.Add(Me.btnN)
        Me.gpeMove.Location = New System.Drawing.Point(254, 9)
        Me.gpeMove.Name = "gpeMove"
        Me.gpeMove.Size = New System.Drawing.Size(265, 139)
        Me.gpeMove.TabIndex = 3
        Me.gpeMove.TabStop = False
        Me.gpeMove.Text = "Déplacer Chevalier"
        '
        'btnPasAPas
        '
        Me.btnPasAPas.Location = New System.Drawing.Point(152, 60)
        Me.btnPasAPas.Name = "btnPasAPas"
        Me.btnPasAPas.Size = New System.Drawing.Size(105, 35)
        Me.btnPasAPas.TabIndex = 9
        Me.btnPasAPas.Text = "Pas à pas"
        Me.btnPasAPas.UseVisualStyleBackColor = True
        '
        'btnAuto
        '
        Me.btnAuto.Location = New System.Drawing.Point(152, 19)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.Size = New System.Drawing.Size(105, 35)
        Me.btnAuto.TabIndex = 8
        Me.btnAuto.Text = "Automatique"
        Me.btnAuto.UseVisualStyleBackColor = True
        '
        'btnNO
        '
        Me.btnNO.Location = New System.Drawing.Point(6, 19)
        Me.btnNO.Name = "btnNO"
        Me.btnNO.Size = New System.Drawing.Size(35, 35)
        Me.btnNO.TabIndex = 7
        Me.btnNO.Text = "NO"
        Me.btnNO.UseVisualStyleBackColor = True
        '
        'btnO
        '
        Me.btnO.Location = New System.Drawing.Point(6, 60)
        Me.btnO.Name = "btnO"
        Me.btnO.Size = New System.Drawing.Size(35, 35)
        Me.btnO.TabIndex = 6
        Me.btnO.Text = "O"
        Me.btnO.UseVisualStyleBackColor = True
        '
        'btnSO
        '
        Me.btnSO.Location = New System.Drawing.Point(6, 101)
        Me.btnSO.Name = "btnSO"
        Me.btnSO.Size = New System.Drawing.Size(35, 35)
        Me.btnSO.TabIndex = 5
        Me.btnSO.Text = "SO"
        Me.btnSO.UseVisualStyleBackColor = True
        '
        'btnS
        '
        Me.btnS.Location = New System.Drawing.Point(45, 101)
        Me.btnS.Name = "btnS"
        Me.btnS.Size = New System.Drawing.Size(35, 35)
        Me.btnS.TabIndex = 4
        Me.btnS.Text = "S"
        Me.btnS.UseVisualStyleBackColor = True
        '
        'btnSE
        '
        Me.btnSE.Location = New System.Drawing.Point(86, 101)
        Me.btnSE.Name = "btnSE"
        Me.btnSE.Size = New System.Drawing.Size(35, 35)
        Me.btnSE.TabIndex = 3
        Me.btnSE.Text = "SE"
        Me.btnSE.UseVisualStyleBackColor = True
        '
        'btnE
        '
        Me.btnE.Location = New System.Drawing.Point(86, 60)
        Me.btnE.Name = "btnE"
        Me.btnE.Size = New System.Drawing.Size(35, 35)
        Me.btnE.TabIndex = 2
        Me.btnE.Text = "E"
        Me.btnE.UseVisualStyleBackColor = True
        '
        'btnNE
        '
        Me.btnNE.Location = New System.Drawing.Point(86, 19)
        Me.btnNE.Name = "btnNE"
        Me.btnNE.Size = New System.Drawing.Size(35, 35)
        Me.btnNE.TabIndex = 1
        Me.btnNE.Text = "NE"
        Me.btnNE.UseVisualStyleBackColor = True
        '
        'btnN
        '
        Me.btnN.Location = New System.Drawing.Point(45, 19)
        Me.btnN.Name = "btnN"
        Me.btnN.Size = New System.Drawing.Size(35, 35)
        Me.btnN.TabIndex = 0
        Me.btnN.Text = "N"
        Me.btnN.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblInformations)
        Me.GroupBox1.Location = New System.Drawing.Point(254, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(265, 55)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informations"
        '
        'lblInformations
        '
        Me.lblInformations.AutoSize = True
        Me.lblInformations.Location = New System.Drawing.Point(19, 26)
        Me.lblInformations.Name = "lblInformations"
        Me.lblInformations.Size = New System.Drawing.Size(39, 13)
        Me.lblInformations.TabIndex = 0
        Me.lblInformations.Text = "Label1"
        '
        'timerPas
        '
        '
        'timerFantome
        '
        '
        'btnFantomes
        '
        Me.btnFantomes.Location = New System.Drawing.Point(254, 215)
        Me.btnFantomes.Name = "btnFantomes"
        Me.btnFantomes.Size = New System.Drawing.Size(129, 23)
        Me.btnFantomes.TabIndex = 5
        Me.btnFantomes.Text = "Activer fantômes"
        Me.btnFantomes.UseVisualStyleBackColor = True
        '
        'chkBloquerFantomes
        '
        Me.chkBloquerFantomes.AutoSize = True
        Me.chkBloquerFantomes.Location = New System.Drawing.Point(400, 220)
        Me.chkBloquerFantomes.Name = "chkBloquerFantomes"
        Me.chkBloquerFantomes.Size = New System.Drawing.Size(111, 17)
        Me.chkBloquerFantomes.TabIndex = 6
        Me.chkBloquerFantomes.Text = "Bloquer Fantômes"
        Me.chkBloquerFantomes.UseVisualStyleBackColor = True
        '
        'frmJeu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 249)
        Me.Controls.Add(Me.chkBloquerFantomes)
        Me.Controls.Add(Me.btnFantomes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpeMove)
        Me.Controls.Add(Me.pnlLabyrinthe)
        Me.Name = "frmJeu"
        Me.Text = "Le jeu dont vous êtes le héros ..."
        Me.gpeMove.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlLabyrinthe As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gpeMove As System.Windows.Forms.GroupBox
    Friend WithEvents btnNO As System.Windows.Forms.Button
    Friend WithEvents btnO As System.Windows.Forms.Button
    Friend WithEvents btnSO As System.Windows.Forms.Button
    Friend WithEvents btnS As System.Windows.Forms.Button
    Friend WithEvents btnSE As System.Windows.Forms.Button
    Friend WithEvents btnE As System.Windows.Forms.Button
    Friend WithEvents btnNE As System.Windows.Forms.Button
    Friend WithEvents btnN As System.Windows.Forms.Button
    Friend WithEvents btnPasAPas As System.Windows.Forms.Button
    Friend WithEvents btnAuto As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblInformations As System.Windows.Forms.Label
    Friend WithEvents timerPas As System.Windows.Forms.Timer
    Friend WithEvents timerFantome As System.Windows.Forms.Timer
    Friend WithEvents btnFantomes As System.Windows.Forms.Button
    Friend WithEvents chkBloquerFantomes As System.Windows.Forms.CheckBox

End Class
