Imports Infragistics.Win.UltraWinGrid
Imports SPC.Server.ReportService
Public Class frmAirports

    Private MessageForm As frmMessage
    Private dtAirport As New DataTable("dtAirport")
    Private dtAirportSimp As New DataTable("dtAirportSimpl")

    Public Sub RefreshData()
        ugdAirports.DataSource = dtAirport
        SetDisplayedColumns()
    End Sub

    Private Sub SetGridDataSource()
        dtAirport.Columns.Add("nombrePais", GetType(String))
        dtAirport.Columns.Add("nombreCiudad", GetType(String))
        dtAirport.Columns.Add("idAeropuerto", GetType(Guid))
        dtAirport.Columns.Add("idPais", GetType(Guid))
        dtAirport.Columns.Add("idCiudad", GetType(Guid))
        dtAirport.Columns.Add("nombreAeropuerto", GetType(String))
        dtAirport.Columns.Add("direccionAeropuerto", GetType(String))
        dtAirport.Columns.Add("observacionAeropuerto", GetType(String))
        dtAirport.Columns.Add("codigoIATA", GetType(String))
        dtAirport.Columns.Add("codigoOACI", GetType(String))
        dtAirport.Columns.Add("paginaWeb", GetType(String))
        dtAirport.Columns.Add("telefonoAeropuerto", GetType(String))
        dtAirport.Columns.Add("numeroTerminales", GetType(Integer))
        dtAirport.Columns.Add("longitudAeropuerto", GetType(String))
        dtAirport.Columns.Add("latitudAeropuerto", GetType(String))

        dtAirportSimp.Columns.Add("nombrePais", GetType(String))
        dtAirportSimp.Columns.Add("nombreCiudad", GetType(String))
        dtAirportSimp.Columns.Add("idAeropuerto", GetType(Guid))
        dtAirportSimp.Columns.Add("idPais", GetType(Guid))
        dtAirportSimp.Columns.Add("idCiudad", GetType(Guid))
        dtAirportSimp.Columns.Add("nombreAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("direccionAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("observacionAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("codigoIATA", GetType(String))
        dtAirportSimp.Columns.Add("codigoOACI", GetType(String))
        dtAirportSimp.Columns.Add("paginaWeb", GetType(String))
        dtAirportSimp.Columns.Add("telefonoAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("numeroTerminales", GetType(Integer))
        dtAirportSimp.Columns.Add("longitudAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("latitudAeropuerto", GetType(String))
    End Sub

    Private Sub SetGridDataSourceSimp()
        dtAirportSimp.Columns.Add("nombrePais", GetType(String))
        dtAirportSimp.Columns.Add("nombreCiudad", GetType(String))
        dtAirportSimp.Columns.Add("idAeropuerto", GetType(Guid))
        dtAirportSimp.Columns.Add("idPais", GetType(Guid))
        dtAirportSimp.Columns.Add("idCiudad", GetType(Guid))
        dtAirportSimp.Columns.Add("nombreAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("direccionAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("observacionAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("codigoIATA", GetType(String))
        dtAirportSimp.Columns.Add("codigoOACI", GetType(String))
        dtAirportSimp.Columns.Add("paginaWeb", GetType(String))
        dtAirportSimp.Columns.Add("telefonoAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("numeroTerminales", GetType(Integer))
        dtAirportSimp.Columns.Add("longitudAeropuerto", GetType(String))
        dtAirportSimp.Columns.Add("latitudAeropuerto", GetType(String))
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdAirports.DisplayLayout.Bands(0).Columns("nombrePais").Header.Caption = "País"
            ugdAirports.DisplayLayout.Bands(0).Columns("nombreCiudad").Header.Caption = "Ciudad"
            ugdAirports.DisplayLayout.Bands(0).Columns("idAeropuerto").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("idPais").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("idCiudad").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("nombreAeropuerto").Header.Caption = "Nombre del Aeropuerto"
            ugdAirports.DisplayLayout.Bands(0).Columns("direccionAeropuerto").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("observacionAeropuerto").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("codigoIATA").Header.Caption = "Código IATA"
            ugdAirports.DisplayLayout.Bands(0).Columns("codigoOACI").Header.Caption = "Código OACI"
            ugdAirports.DisplayLayout.Bands(0).Columns("paginaWeb").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("telefonoAeropuerto").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("numeroTerminales").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("longitudAeropuerto").Hidden = True
            ugdAirports.DisplayLayout.Bands(0).Columns("latitudAeropuerto").Hidden = True
            ugdAirports.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShowAirportDetails(id As Guid)
        Using frmDetails As New frmAirporDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub


    Private Sub frmAirports_Load(sender As Object, e As EventArgs) Handles Me.Load
        uceMetBusq.SelectedIndex = 0
        SetGridDataSource()
        dtAirport = CommonData.GetAirportCatalog()
        RefreshData()
    End Sub

    Private Sub cargarComboAirpotSimple()
        uceBusq.Items.Clear()
        uceBusq.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In dtAirport.Rows
            uceBusq.Items.Add(r.Item("idAeropuerto"), r.Item("nombreAeropuerto"))
        Next
        uceBusq.SelectedIndex = 0
    End Sub

    Private Sub cargarComboAirpotIATA()
        uceBusq.Items.Clear()
        uceBusq.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In dtAirport.Rows
            uceBusq.Items.Add(r.Item("idAeropuerto"), r.Item("codigoIATA"))
        Next
        uceBusq.SelectedIndex = 0
    End Sub

    Private Sub cargarComboPais()
        uceBusq.Items.Clear()
        uceBusq.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetPais().Rows
            uceBusq.Items.Add(r.Item("idPais"), r.Item("NombrePais"))
        Next
        uceBusq.SelectedIndex = 0
    End Sub

    Private Sub uceMetBusq_ValueChanged(sender As Object, e As EventArgs) Handles uceMetBusq.SelectionChanged
        If uceMetBusq.Value = "esc" Then uceBusq.Enabled = False Else uceBusq.Enabled = True
        If uceMetBusq.Value = "pai" Then cargarComboPais()
        If uceMetBusq.Value = "cod" Then cargarComboAirpotIATA()
        If uceMetBusq.Value = "aer" Then cargarComboAirpotSimple()
    End Sub

    Public Function obtenerAeropuerto(ByVal id As Guid) As DataTable
        dtAirportSimp = New DataTable("dtAirportSimpl")
        SetGridDataSourceSimp()
        Dim nr As DataRow
        For Each r As DataRow In dtAirport.Rows
            If r.Item("idAeropuerto") = id Then
                nr = dtAirportSimp.NewRow
                nr.Item("nombrePais") = r.Item("nombrePais")
                nr.Item("nombreCiudad") = r.Item("nombreCiudad")
                nr.Item("idAeropuerto") = r.Item("idAeropuerto")
                nr.Item("idPais") = r.Item("idPais")
                nr.Item("idCiudad") = r.Item("idCiudad")
                nr.Item("nombreAeropuerto") = r.Item("nombreAeropuerto")
                nr.Item("direccionAeropuerto") = r.Item("direccionAeropuerto")
                nr.Item("observacionAeropuerto") = r.Item("observacionAeropuerto")
                nr.Item("codigoIATA") = r.Item("codigoIATA")
                nr.Item("codigoOACI") = r.Item("codigoOACI")
                nr.Item("paginaWeb") = r.Item("paginaWeb")
                nr.Item("telefonoAeropuerto") = r.Item("telefonoAeropuerto")
                nr.Item("numeroTerminales") = r.Item("numeroTerminales")
                nr.Item("longitudAeropuerto") = r.Item("longitudAeropuerto")
                nr.Item("latitudAeropuerto") = r.Item("latitudAeropuerto")
                dtAirportSimp.Rows.Add(nr)
            End If
        Next
        Return dtAirportSimp
    End Function

    Private Sub ShowWaitForm()
        Try
            MessageForm = New frmMessage("Descargando catálogo, por favor espere", "Descarga")
            'MessageForm.SetMessage("Descargando catálogo, por favor espere")
            MessageForm.ShowDialog()
            Application.DoEvents()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Select Case uceMetBusq.Value
            Case "pai"
                If uceBusq.Text <> "Escoja una opción" Then
                    ugdAirports.DataSource = CommonData.GetAeropuertoPorIdPais(uceBusq.Value)
                    SetDisplayedColumns()
                Else
                    MessageBox.Show("Seleccione un País", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case "cod"
                If uceBusq.Text <> "Escoja una opción" Then
                    ugdAirports.DataSource = CommonData.GetAeropuertoPorIdPais(uceBusq.Value)
                    SetDisplayedColumns()
                Else
                    MessageBox.Show("Seleccione un Código", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case "aer"
                If uceBusq.Text <> "Escoja una opción" Then
                    ugdAirports.DataSource = obtenerAeropuerto(uceBusq.Value)
                    SetDisplayedColumns()
                Else
                    MessageBox.Show("Seleccione un Aeropuerto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
        End Select
    End Sub

    Private Sub ugdAirports_DoubleClickCell1(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdAirports.DoubleClickCell
        If Not ugdAirports.ActiveRow.Cells("idAeropuerto").Value.ToString = String.Empty Then
            ShowAirportDetails(ugdAirports.ActiveRow.Cells("idAeropuerto").Value)
        Else
            Using frmDetails As New frmAirporDetails(True)
                frmDetails.ShowDialog()
            End Using
            RefreshData()
        End If
    End Sub

    Private Sub ugdAirports_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugdAirports.InitializeLayout

    End Sub
End Class