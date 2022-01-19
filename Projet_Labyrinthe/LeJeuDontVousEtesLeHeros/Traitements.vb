Imports System
Imports System.IO

Public Module Traitements
    'lire labyrinthe depuis fichier
    Public Sub LireLabyrinthe(ByRef laby(,) As Dalle)
        Dim path As String = "labyrinthe_1.csv"
        Dim i As Integer
        Dim j As Integer
        i = 0
        If File.Exists(path) Then
            Dim tmp_ligne() As String
            For Each ligne As String In File.ReadLines(path)
                tmp_ligne = Split(ligne, ";")
                For j = 0 To 10
                    If StrComp(tmp_ligne(j), "m") = 0 Then
                        laby(i, j).mur = True
                    Else
                        laby(i, j).mur = False
                    End If

                    laby(i, j).position.x = i
                    laby(i, j).position.y = j

                    laby(i, j).distanceCible = Integer.MaxValue
                Next
                i = i + 1
            Next ligne
        End If
    End Sub
    'Place la princesse
    Public Sub placerPrincesse()
        Cunegonde.position.x = 10
        Cunegonde.position.y = 1
        Cunegonde.secourue = False
    End Sub

    'Place le chevalier sans armure dans le labyrinthe
    Public Sub placerChevalier(ByRef c As Chevalier)
        c.position.x = 0
        c.position.y = 9
        c.vivant = True
        c.avecPrincesse = False
        c.armures = 0
    End Sub

    'Déplacer le chevalierd'un pas dans une direction
    Public Sub deplacerChevalier(ByVal direction As String, ByRef c As Chevalier)
        Dim newX As Integer
        Dim newY As Integer
        If StrComp(direction, "NO") = 0 Then
            newX = c.position.x - 1
            newY = c.position.y - 1
        ElseIf StrComp(direction, "N") = 0 Then
            newX = c.position.x - 1
            newY = c.position.y
        ElseIf StrComp(direction, "NE") = 0 Then
            newX = c.position.x - 1
            newY = c.position.y + 1
        ElseIf StrComp(direction, "E") = 0 Then
            newX = c.position.x
            newY = c.position.y + 1
        ElseIf StrComp(direction, "SE") = 0 Then
            newX = c.position.x + 1
            newY = c.position.y + 1
        ElseIf StrComp(direction, "S") = 0 Then
            newX = c.position.x + 1
            newY = c.position.y
        ElseIf StrComp(direction, "SO") = 0 Then
            newX = c.position.x + 1
            newY = c.position.y - 1
        ElseIf StrComp(direction, "O") = 0 Then
            newX = c.position.x
            newY = c.position.y - 1
        End If

        'Tester si le chevalier peut se déplacer
        If newX >= 0 And newX < 11 And newY >= 0 And newY < 11 Then
            If labyrinthe(newX, newY).mur = False Then
                c.position.x = newX
                c.position.y = newY
            End If
        End If
    End Sub

    'Evaluer la situation du chevalier et de la princesse dans le labyrinthe
    Public Sub evaluerSituation(ByRef c As Chevalier)
        'Tester si le chevalier a rejoint la princesse
        If c.position.x = Cunegonde.position.x And c.position.y = Cunegonde.position.y Then
            c.avecPrincesse = True
            Cunegonde.secourue = True
        End If

        'Tester si le chevalier a retrouvé une armure
        If c.position.x=armures(0).position.x And c.position.y=armures(0).position.y And armures(0).ramassee=false then
            c.armures=(c.armures)+1
            armures(0).ramassee=true
        End If
        If c.position.x=armures(1).position.x And c.position.y=armures(1).position.y And armures(1).ramassee=false then
            c.armures=(c.armures)+1
            armures(1).ramassee=true
        End If
        If c.position.x=armures(2).position.x And c.position.y=armures(2).position.y And armures(2).ramassee=false then
            c.armures=(c.armures)+1
            armures(2).ramassee=true
        End If

        'Tester si le chevalier a recontré un fantôme
        If c.position.x=fantomes(0).position.x And c.position.y=fantomes(0).position.y then
            if c.armures<3 Then
                c.vivant=false
            Else fantomes(0).vaincu=True
            End if
        End If
        If c.position.x=fantomes(1).position.x And c.position.y=fantomes(1).position.y then
            if c.armures<3 Then
                c.vivant=false
            Else fantomes(1).vaincu=True
            End if
        End If
    End Sub

    'Retire un élément en début du tableau T
    Public Function retirerTete(ByRef T() As Dalle, ByRef TailleT As Integer) As Dalle
        Dim d As Dalle
        If TailleT > 0 Then
            d = T(0)
            Dim i As Integer
            For i = 0 To TailleT - 2
                T(i) = T(i + 1)
            Next
            TailleT = TailleT - 1
        End If
        Return d
    End Function

    'Ajoute un élément à la fin du tableau T
    Public Sub ajouterQueue(ByRef T() As Dalle, ByRef TailleT As Integer, ByRef d As Dalle)
        T(TailleT) = d
        TailleT = TailleT + 1
    End Sub

    'Calculer la distance à la princesse de toutes les cases du labyrinthe
    Public Sub calculerDistancesPrincesse(ByRef laby(,) As Dalle)
        Dim aTraiter(11 * 11) As Dalle
        Dim tailleATraiter As Integer = 0

        Dim i As Integer
        Dim j As Integer
        Dim X As Integer
        Dim Y As Integer

        'Reset des valeurs initiales des distances au cas où
        For i = 0 To 10
            For j = 0 To 10
                laby(i, j).distanceCible = Integer.MaxValue
            Next
        Next

        'On démarre de la position de la princesse en ajoutant la case correspondante dans la liste des "à traiter"
        laby(Cunegonde.position.x, Cunegonde.position.y).distanceCible = 0
        ajouterQueue(aTraiter, tailleATraiter, laby(Cunegonde.position.x, Cunegonde.position.y))

        'Tant que j'ai des cases à traiter, je vérifie les 8 voisins de la première case de la liste des "à traiter"
        While tailleATraiter > 0
            For i = -1 To 1
                X = aTraiter(0).position.x + i
                If X >= 0 And X < 11 Then
                    For j = -1 To 1
                        Y = aTraiter(0).position.y + j
                        If Y >= 0 And Y < 11 Then
                            If Not (laby(X, Y).mur) Then 
                                If Not ((fantomes(0).position.x=X And fantomes(0).position.y=Y) Or (fantomes(1).position.x=X And fantomes(1).position.y=Y))
                                'Si la case voisine n'est pas un mur,  et si la nouvelle valeur de distance est inférieure à sa valeur actuelle, 
                                'alors je modifie sa distance à la princesse
                                If laby(X, Y).distanceCible > aTraiter(0).distanceCible + 1 Then
                                    laby(X, Y).distanceCible = aTraiter(0).distanceCible + 1
                                    'Et je l'ajoute dans les cases à traiter
                                    ajouterQueue(aTraiter, tailleATraiter, laby(X, Y))
                                End if
                                End if
                            End If
                        End If
                    Next
                End If
            Next
            retirerTete(aTraiter, tailleATraiter)  'Je retire la case que je vient de traiter de la liste des cases à traiter ...
        End While
    End Sub

    'Déplacer le chevalier d'un pas en cherchant le plus court chemin vers sa cible
    Public Sub deplacerChevalierAuto(ByRef c As Chevalier)
        Dim i As Integer
        Dim j As Integer
        Dim distMin As Integer = Integer.MaxValue
        Dim dirMin As String = ""
        Dim x As Integer
        Dim y As Integer
        Dim xmin As Integer
        Dim ymin As Integer

        'Rechercher la direction vers la distance minimale sur les 8 voisins de la position actuelle du chevalier
        For i = -1 To 1
            x = c.position.x + i
            If x >= 0 And x < 11 Then
                For j = -1 To 1
                    y = c.position.y + j
                    If y >= 0 And y < 11 
                        If (Not (i = 0 And j = 0)) And labyrinthe(x, y).mur = False And labyrinthe(x, y).distanceCible < distMin Then
                            distMin = labyrinthe(x, y).distanceCible
                            xmin = x
                            ymin = y
                            dirMin = ""
                            If i = -1 and (fantomes(0).position.x<>i-1) And (fantomes(1).position.x<>i-1)Then
                                dirMin = dirMin + "N"
                            ElseIf i = 1 and (fantomes(0).position.x<>i+1) And (fantomes(1).position.x<>i+1)Then
                                dirMin = dirMin + "S"
                            End If
                            If j = -1 and (fantomes(0).position.y<>i-1) And (fantomes(1).position.y<>i-1)Then
                                dirMin = dirMin + "O"
                            ElseIf j = 1 And (fantomes(0).position.y<>i+1) And (fantomes(1).position.y<>i+1) Then
                                dirMin = dirMin + "E"
                            End If
                        End If
                    End If
                Next
            End If
        Next
        'Déplacer le chevalier dans la bonne direction
        deplacerChevalier(dirMin, c)
    End Sub

    'Place les armures
    Public Sub placerArmures()
        armures(0).position.x=6
        armures(0).position.y=3
        armures(0).ramassee=false
        armures(1).position.x=7
        armures(1).position.y=7
        armures(1).ramassee=false
        armures(2).position.x=1     
        armures(2).position.y=5
        armures(2).ramassee=false

    End Sub

    'Place les fantomes
    Public Sub placerFantomes()
        Fantomes(0).position.x=8
        Fantomes(0).position.y=3
        Fantomes(0).vaincu=false
        Fantomes(1).position.x=5    
        Fantomes(1).position.y=7
        Fantomes(1).vaincu=false

    End Sub

    'Calculer la distance à la cible de toutes les cases du labyrinthe
    Public Sub calculerDistances(ByVal cible As Position)
        Dim aTraiter(11 * 11) As Dalle
        Dim tailleATraiter As Integer = 0

        Dim i As Integer
        Dim j As Integer
        Dim X As Integer
        Dim Y As Integer

        'Reset des valeurs initiales des distances au cas où
        For i = 0 To 10
            For j = 0 To 10
                labyrinthe(i, j).distanceCible = Integer.MaxValue
            Next
        Next

        'On démarre de la position de la princesse en ajoutant la case correspondante dans la liste des "à traiter"
        labyrinthe(cible.x, cible.y).distanceCible = 0
        ajouterQueue(aTraiter, tailleATraiter, labyrinthe(cible.x, cible.y))

        'Tant que j'ai des cases à traiter, je vérifie les 8 voisins de la première case de la liste des "à traiter"
        While tailleATraiter > 0
            For i = -1 To 1
                X = aTraiter(0).position.x + i
                If X >= 0 And X < 11 Then
                    For j = -1 To 1
                        Y = aTraiter(0).position.y + j
                        If Y >= 0 And Y < 11 Then
                            If Not (labyrinthe(X, Y).mur) Then
                                If Not (((fantomes(0).position.x=X And fantomes(0).position.y=Y) Or (fantomes(1).position.x=X And fantomes(1).position.y=Y))) 
                                'Si la case voisine n'est pas un mur (ni un fantome),  et si la nouvelle valeur de distance est inférieure à sa valeur actuelle, 
                                'alors je modifie sa distance à la princesse
                                If labyrinthe(X, Y).distanceCible > aTraiter(0).distanceCible + 1 Then
                                    labyrinthe(X, Y).distanceCible = aTraiter(0).distanceCible + 1
                                    'Et je l'ajoute dans les cases à traiter
                                    ajouterQueue(aTraiter, tailleATraiter, labyrinthe(X, Y))
                                End If
                                End if
                            End If
                        End If
                    Next
                End If
            Next
            retirerTete(aTraiter, tailleATraiter)  'Je retire la case que je vient de traiter de la liste des cases à traiter ...
        End While
    End Sub

    'Déplacer les deux fantômes
    'ATTENTION : un fantôme ne se déplace que s'il n'est pas vaincu
    Public Sub deplacerFantomes()
        Dim directiongauche As Boolean

        'problème dans le déplacement une fois la direction changée
        'fantome 1
        If fantomes(0).vaincu=False then
        directiongauche=false
        If fantomes(0).position.y+1=10 Then
        directiongauche=True
        End If
        If fantomes(0).position.y-1=0 Then
        directiongauche=false
        End If
        If directiongauche=True then
        fantomes(0).position.y=fantomes(0).position.y-1
        else
        fantomes(0).position.y=fantomes(0).position.y+1
        End if
        End if

        'fantome 2
        If fantomes(1).vaincu=False then
        directiongauche=false
        If fantomes(1).position.x+1=10 Then
        directiongauche=True
        End If
        If fantomes(1).position.x-1=0 Then
        directiongauche=false
        End If
        If directiongauche=True then
        fantomes(1).position.x=fantomes(1).position.x-1
        else
        fantomes(1).position.x=fantomes(1).position.x+1
        End if
        End if
    End Sub

    'Détermine si le chevalier doit faire un pas vers une pièce d'armure ou vers la princesse
    Public Sub unPas(ByRef c As Chevalier)
        Dim i As Double
        For i=0 To 2
        If armures(i).ramassee=False then
       calculerDistances(armures(i).position)
        End if
        next
        If armures(0).ramassee=true And armures(1).ramassee=true and armures(2).ramassee=true Then
         calculerDistancesPrincesse(labyrinthe)
        End if
        deplacerChevalierAuto(c)
    End Sub

End Module