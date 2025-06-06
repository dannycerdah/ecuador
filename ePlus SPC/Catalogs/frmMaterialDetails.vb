﻿Imports SPC.Server.ReportService
Public Class frmMaterialDetails
    Public Property myMaterial As New MaterialesItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewMaterial As Boolean = False

    Private Sub InitializeValues()
        myMaterial.idMaterial = String.Empty
        myMaterial.descripcion = ""
    End Sub

    Public Sub New(ByVal myMaterialItem As MaterialesItem)
        InitializeComponent()
        InitializeValues()
        myMaterial = myMaterialItem
    End Sub

    Public Sub New(MustCreateNewMterial As Boolean)
        InitializeComponent()
        InitializeValues()
        myMaterial.idMaterial = txtCodigo.Text
        IsNewMaterial = True
    End Sub

    Public Sub New(ByVal MaterialId As String)
        InitializeComponent()
        InitializeValues()
        myMaterial = CommonData.GetMaterialItem(MaterialId)
    End Sub


    Private Sub frmMaterialDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillMaterialInfo()
    End Sub

    Private Sub FillMaterialInfo()
        If Not IsNewMaterial Then
            txtCodigo.Text = myMaterial.idMaterial
            txtDescripcion.Text = myMaterial.descripcion
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New MaterialesRequest
        Dim res As New MaterialesResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            If txtCodigo.Text = "" Then
                MessageBox.Show("Ingrese Código", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If IsNewMaterial Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                CamionInfoToObject()
                req.myMaterial = myMaterial
                res = wsClnt.SaveMaterialInfo(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
        Me.Close()
    End Sub

    Private Sub CamionInfoToObject()
        If IsNewMaterial Then
            myMaterial.idMaterial = txtCodigo.Text
        End If
        myMaterial.descripcion = txtDescripcion.Text
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

End Class

