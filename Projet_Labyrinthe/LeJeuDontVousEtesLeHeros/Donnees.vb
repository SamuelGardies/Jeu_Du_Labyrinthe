Public Module Donnees
    'Données et structures globales
    'Structure pour les cases du labyrinthe
    Public Structure Dalle
        Dim position As Position
        Dim mur As Boolean
        Dim distanceCible As Integer
    End Structure
    'Structure pour la position des personnages dans le labyrinthe
    Public Structure Position
        Dim x As Integer
        Dim y As Integer
    End Structure
    Public Structure Chevalier
        Dim position As Position
        Dim vivant As Boolean
        Dim avecPrincesse As Boolean
        Dim armures As Integer
    End Structure
    Public Structure Princesse
        Dim position As Position
        Dim secourue As Boolean
    End Structure

    Public Structure Fantome
        Dim position As Position
        Dim direction As String     'Seulement "N", "E", "S", "O" autorisées
        Dim vaincu As Boolean
    End Structure

    Public Structure Armure
        Dim position As Position
        Dim ramassee As Boolean
    End Structure

    'Données relatives au labyrinthe
    Public Const tailleLabyrinthe As Integer = 11
    Public labyrinthe(tailleLabyrinthe, tailleLabyrinthe) As Dalle

    'Données relatives au chevalier
    Public Bayard As Chevalier

    'Données relatives à la princesse
    Public Cunegonde As Princesse

    'Données relatives aux fantômes
    Public fantomes(2) As Fantome

    'Données relatives aux armures
    Public armures(3) As Armure
End Module
