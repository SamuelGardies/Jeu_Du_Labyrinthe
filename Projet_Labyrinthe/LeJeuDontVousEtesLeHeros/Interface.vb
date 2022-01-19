Public Class frmJeu
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Régler les timers
        timerPas.Interval = 500
        timerFantome.Interval = 500

        'Créer la matrice de picturebox pour afficher le labyrinthe
        Dim pb As PictureBox
        For i = 0 To 10
            For j = 0 To 10
                pb = New PictureBox
                pb.BackColor = Color.White

                pb.Height = 20
                pb.Width = 20
                pb.Margin = New Padding(0)

                pnlLabyrinthe.Controls.Add(pb)
            Next
        Next

        'Créer le labyrinthe 1
        'CreerLabyrinthe1(labyrinthe)

        'Lire le labyrinthe
        LireLabyrinthe(labyrinthe)

        'Placer la princesse
        placerPrincesse()

        'Placer le chevalier
        placerChevalier(Bayard)

        'Placer les armures
        placerArmures()

        'Placer les fantomes
        placerFantomes()

        'Calculer distances
        calculerDistancesPrincesse(labyrinthe)
    End Sub

    'Affiche le labyrinthe, le chavalier, la princesse, les armures et les fantômes.
    'Il faut appeler Me.Refresh à chaque fois qu'on modifie un de ces éléments
    Private Sub afficherLabyrinthe(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlLabyrinthe.Paint
        Dim i As Integer
        Dim j As Integer
        Dim pb As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics
        Dim b As Brush

        'Le labyrinthe
        For i = 0 To tailleLabyrinthe - 1
            For j = 0 To tailleLabyrinthe - 1
                'La pictureBox correspondant à la case du labyrinthe
                pb = pnlLabyrinthe.Controls(i * tailleLabyrinthe + j)

                bmp = New Bitmap(pb.Width, pb.Height)
                g = Graphics.FromImage(bmp)
                pb.Image = bmp

                'Les murs
                If labyrinthe(i, j).mur = True Then
                    'pb.BackColor = Color.Black
                    b = Brushes.Black
                    g.FillRectangle(b, 0, 0, 20, 20)

                Else
                    'pb.BackColor = Color.White
                    b = Brushes.White
                    g.FillRectangle(b, 0, 0, 20, 20)
                End If

                If labyrinthe(i, j).distanceCible < Integer.MaxValue Then
                    g.DrawString(Str(labyrinthe(i, j).distanceCible), New Font("Arial", 6), Brushes.Red, 1, 1)
                End If
            Next
        Next

        'Le chevalier
        pb = pnlLabyrinthe.Controls(Bayard.position.x * tailleLabyrinthe + Bayard.position.y)
        g = Graphics.FromImage(pb.Image)
        If Bayard.vivant Then
            g.FillEllipse(Brushes.Gray, 3, 3, 10 + Bayard.armures, 10 + Bayard.armures)
            g.FillEllipse(Brushes.Blue, 4, 4, 10, 10)
        Else
            g.FillEllipse(Brushes.Red, 4, 6, 12, 6)
        End If


        'La princesse
        pb = pnlLabyrinthe.Controls(Cunegonde.position.x * tailleLabyrinthe + Cunegonde.position.y)
        g = Graphics.FromImage(pb.Image)
        If Bayard.avecPrincesse Then
            g.FillEllipse(Brushes.Purple, 4, 4, 10, 10)
        Else
            g.FillEllipse(Brushes.Pink, 4, 4, 10, 10)
        End If

        'Les armures
        For i = 0 To 2
            If armures(i).ramassee = False Then
                pb = pnlLabyrinthe.Controls(armures(i).position.x * tailleLabyrinthe + armures(i).position.y)
                g = Graphics.FromImage(pb.Image)
                g.FillRectangle(Brushes.Gray, 10, 10, 5, 5)
            End If
        Next

        'Les fantômes
        For i = 0 To 1
            pb = pnlLabyrinthe.Controls(fantomes(i).position.x * tailleLabyrinthe + fantomes(i).position.y)
            g = Graphics.FromImage(pb.Image)
            If fantomes(i).vaincu Then
                g.FillEllipse(Brushes.LightGreen, 4, 6, 12, 6)
            Else
                g.FillEllipse(Brushes.Green, 4, 4, 10, 10)
            End If
        Next

        'Afficher les informations
        lblInformations.Text = ""
        If Bayard.vivant Then
            If Bayard.avecPrincesse Then
                lblInformations.Text = "La princesse est sauvée !"
            Else
                lblInformations.Text = "Jusqu'ici tout va bien ..."
            End If
        Else
            lblInformations.Text = "Le chevalier est mort, la princesse s'ennuie ..."
        End If
    End Sub

    Private Sub btnN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnN.Click
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            deplacerChevalier("N", Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub


    Private Sub btnNE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNE.Click
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            deplacerChevalier("NE", Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub


    Private Sub btnE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnE.Click
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            deplacerChevalier("E", Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub


    Private Sub btnSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSE.Click
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            deplacerChevalier("SE", Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub

    Private Sub btnS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnS.Click
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            deplacerChevalier("S", Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub

    Private Sub btnSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSO.Click
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            deplacerChevalier("SO", Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub

    Private Sub btnO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnO.Click
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            deplacerChevalier("O", Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub

    Private Sub btnNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNO.Click
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            deplacerChevalier("NO", Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub

    Private Sub btnPasAPas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasAPas.Click
        If Not timerFantome.Enabled And Not chkBloquerFantomes.Checked Then
            'Deplacer les fantomes
            deplacerFantomes()
        End If

        If timerPas.Enabled Then
            timerPas.Stop()
            btnAuto.Text = "Automatique"
        End If

        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            'Déplacer le chevalier
            unPas(Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If

        'Afficher le labyrinthe
        Me.Refresh()
    End Sub

    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        If Not timerFantome.Enabled Then
            timerFantome.Start()
            btnFantomes.Text = "Stopper fantômes"
        End If

        If timerPas.Enabled Then
            timerPas.Stop()
            btnAuto.Text = "Automatique"
        Else
            timerPas.Start()
            btnAuto.Text = "STOP"
        End If
    End Sub

    Private Sub timerPas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerPas.Tick
        If Bayard.vivant = True And Bayard.avecPrincesse = False Then
            'Déplacer le chevalier
            unPas(Bayard)
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If

        'Afficher le labyrinthe
        Me.Refresh()
    End Sub

    Private Sub timerFantome_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerFantome.Tick
        If Not chkBloquerFantomes.Checked Then
            'Deplacer les fantomes
            deplacerFantomes()
            'Evaluer la nouvelle situation
            evaluerSituation(Bayard)
        End If
        'Afficher le labyrinthe
        Me.Refresh()
    End Sub

    Private Sub btnFantomes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFantomes.Click
        If timerFantome.Enabled Then
            timerFantome.Stop()
            btnFantomes.Text = "Activer fantômes"
        Else
            timerFantome.Start()
            btnFantomes.Text = "Stopper fantômes"
        End If
    End Sub
End Class
