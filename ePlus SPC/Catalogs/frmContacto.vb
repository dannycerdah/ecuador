Public Class frmContacto
    Public Property IdUsuario As String
    Public Sub RefreshData()
        ugdContacto.DataSource = CommonData.GetEntireContactoCatalog()
        SetDisplayedColumns()
        txtContacto.Focus()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdContacto.DisplayLayout.Bands(0).RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout
            Dim firstGroup As Infragistics.Win.UltraWinGrid.UltraGridGroup = ugdContacto.DisplayLayout.Bands(0).Groups.Add("FirstGroup", "Datos Generales")
            Dim SecondGroup As Infragistics.Win.UltraWinGrid.UltraGridGroup = ugdContacto.DisplayLayout.Bands(0).Groups.Add("SecondGroup", "Fechas")
            ugdContacto.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
            ugdContacto.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("tipoDocContacto").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("primerApellidoContacto").Header.Caption = "Primer Apellido"
            ugdContacto.DisplayLayout.Bands(0).Columns("segundoApellidoContacto").Header.Caption = "Segundo Apellido"
            ugdContacto.DisplayLayout.Bands(0).Columns("primerNombreContacto").Header.Caption = "Nombre"
            ugdContacto.DisplayLayout.Bands(0).Columns("segundoNombreContacto").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("idPais").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("idCiudad").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("telefono").Header.Caption = "Teléfono"
            'ugdContacto.DisplayLayout.Bands(0).Columns("correo").Header.Caption = "Correo electrónico"
            ugdContacto.DisplayLayout.Bands(0).Columns("correo").Hidden = True
            'ugdContacto.DisplayLayout.Bands(0).Columns("direccionContacto").Header.Caption = "Dirección"
            ugdContacto.DisplayLayout.Bands(0).Columns("direccionContacto").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("fechaNacimientoContacto").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("tagsaContacto").Header.Caption = "TAGSA"
            ugdContacto.DisplayLayout.Bands(0).Columns("tagsaContacto").Width = 45
            ugdContacto.DisplayLayout.Bands(0).Columns("fechaCaducaTagsa").Header.Caption = "Caducidad TAGSA"
            ugdContacto.DisplayLayout.Bands(0).Columns("fechaCaducaTagsa").Width = 80
            ugdContacto.DisplayLayout.Bands(0).Columns("Compania").Header.Caption = "Compañia"
            ugdContacto.DisplayLayout.Bands(0).Columns("FechaPrimerIngresoGA").Header.Caption = "Primer Ingreso GA"
            ugdContacto.DisplayLayout.Bands(0).Columns("FechaPrimerIngresoGA").Format = "dd/MM/yyyy HH:mm:ss"
            ugdContacto.DisplayLayout.Bands(0).Columns("FechaUltimoIngresoGA").Header.Caption = "Ultimo Ingreso GA"
            ugdContacto.DisplayLayout.Bands(0).Columns("FechaUltimoIngresoGA").Format = "dd/MM/yyyy HH:mm:ss"

            ugdContacto.DisplayLayout.Bands(0).Columns("FechaPrimerIngresoGA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            ugdContacto.DisplayLayout.Bands(0).Columns("FechaUltimoIngresoGA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            ugdContacto.DisplayLayout.Bands(0).Columns("fechaCaducaTagsa").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            ugdContacto.DisplayLayout.Bands(0).Columns("primerApellidoContacto").RowLayoutColumnInfo.ParentGroup = firstGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("tagsaContacto").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            ugdContacto.DisplayLayout.Bands(0).Columns("tagsaContacto").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            ugdContacto.DisplayLayout.Bands(0).Columns("segundoApellidoContacto").RowLayoutColumnInfo.ParentGroup = firstGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("primerNombreContacto").RowLayoutColumnInfo.ParentGroup = firstGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("segundoNombreContacto").RowLayoutColumnInfo.ParentGroup = firstGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("telefono").RowLayoutColumnInfo.ParentGroup = firstGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("tagsaContacto").RowLayoutColumnInfo.ParentGroup = firstGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("Compania").RowLayoutColumnInfo.ParentGroup = firstGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("FechaPrimerIngresoGA").RowLayoutColumnInfo.ParentGroup = SecondGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("FechaUltimoIngresoGA").RowLayoutColumnInfo.ParentGroup = SecondGroup
            ugdContacto.DisplayLayout.Bands(0).Columns("fechaCaducaTagsa").RowLayoutColumnInfo.ParentGroup = SecondGroup
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ugdContacto_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdContacto.DoubleClickCell
        If Not ugdContacto.ActiveRow.Cells("idContacto").Value.ToString = String.Empty Then
            ShowTiposContactoDetails(ugdContacto.ActiveRow.Cells("idContacto").Value)
        Else
            Using frmDetails As New frmContactoDetails(True)
                frmDetails.IdUsuario = IdUsuario 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowTiposContactoDetails(id As String)

        'Dim frmDetails1 As New frmContactoDetails(id)
        'frmDetails1.IdUsuario = IdUsuario
        'frmDetails1.Show()


        Using frmDetails As New frmContactoDetails(id)
            frmDetails.IdUsuario = IdUsuario 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
            frmDetails.ShowDialog()
        End Using





    End Sub

    Private Sub txtContacto_ValueChanged(sender As Object, e As EventArgs) Handles txtContacto.ValueChanged
        If txtContacto.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdContacto.Rows
                If InStr(r.Cells("idContacto").Value, txtContacto.Text) <> 0 Or InStr(r.Cells("primerNombreContacto").Value, txtContacto.Text) Or InStr(r.Cells("primerApellidoContacto").Value, txtContacto.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdContacto.Rows
                r.Hidden = False
            Next
        End If
    End Sub


End Class