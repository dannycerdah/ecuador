Imports SPC.Server.Facturacion
Public Class CommonDataFact
    Public Shared Function MantClientes(datos As Cliente) As Boolean
        Dim Result As Boolean = False
        Dim wsClient As New FacturacionSoapClient
        Dim req As New ClienteRequest
        Dim res As New ClienteResponse
        Try
            General.SetBARequest(req)
            req.UserId = datos.UsuarioIngreso
            req.Cliente = datos
            res = wsClient.MantClientes(req)
            If res.ActionResult Then
                Result = res.ActionResult
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function MantServiciosGA(datos As ServiciosGA) As Boolean
        Dim Result As Boolean = False
        Dim wsClient As New FacturacionSoapClient
        Dim req As New ServiciosGARequest
        Dim res As New ServiciosGAResponse
        Try
            General.SetBARequest(req)
            req.UserId = datos.UsuarioIngreso
            req.ServiciosGA = datos
            res = wsClient.MantServiciosGA(req)
            If res.ActionResult Then
                Result = res.ActionResult
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function MantPeriodicidad(datos As Periodicidad) As Boolean
        Dim Result As Boolean = False
        Dim wsClient As New FacturacionSoapClient
        Dim req As New PeriodicidadRequest
        Dim res As New PeriodicidadResponse
        Try
            General.SetBARequest(req)
            req.UserId = datos.UsuarioIngreso
            req.Periodicidad = datos
            res = wsClient.MantPeriodicidad(req)
            If res.ActionResult Then
                Result = res.ActionResult
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function MantPlantiClienteServ(datos As PlantillaClienServ) As Boolean
        Dim Result As Boolean = False
        Dim wsClient As New FacturacionSoapClient
        Dim req As New PlantillaClienServRequest
        Dim res As New PlantillaClienServResponse
        Try
            General.SetBARequest(req)
            req.UserId = datos.UsuarioIngreso
            req.PlantillaClienteServicio = datos
            res = wsClient.MantPlantiClienteServ(req)
            If res.ActionResult Then
                Result = res.ActionResult
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function MantServConsuCliente(datos As ServConsuCliente) As Boolean
        Dim Result As Boolean = False
        Dim wsClient As New FacturacionSoapClient
        Dim req As New ServConsuClienteRequest
        Dim res As New ServConsuClienteResponse
        Try
            General.SetBARequest(req)
            req.UserId = datos.UsuarioIngreso
            req.ServConsuCliente = datos
            res = wsClient.MantServConsuCliente(req)
            If res.ActionResult Then
                Result = res.ActionResult
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetClientes() As DataTable
        Dim Result As New DataTable("GetClientes")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New ClienteRequest
        Dim res As New ClienteResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetClientes(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetServiciosGA() As DataTable
        Dim Result As New DataTable("GeServiciosGA")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New ServiciosGARequest
        Dim res As New ServiciosGAResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetServiciosGA(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetPeriodicidad() As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New PeriodicidadRequest
        Dim res As New PeriodicidadResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetPeriodicidad(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetPlantiClienteServ(idCliente As Integer) As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New PlantillaClienServRequest
        Dim res As New PlantillaClienServResponse
        Dim Datos As New PlantillaClienServ
        Try
            Datos.IdCliente = idCliente
            req.PlantillaClienteServicio = Datos
            General.SetBARequest(req)
            res = wsClient.GetPlantiClienteServ(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetTipoProceAlmacenaCarga() As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New TipoProcesoAlmacenajeCargaRequest
        Dim res As New TipoProcesoAlmacenajeCargaResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetTipoProceAlmacenaCarga(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function PreFactObtenerPesoVolumenVuelo(IdAgencia As String, FechaInicio As Date, FechaFin As Date) As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New PlantillaClienServRequest
        Dim res As New PlantillaClienServResponse
        Dim Datos As New PlantillaClienServ
        Try
            General.SetBARequest(req)
            With Datos
                .FechaIngreso = FechaInicio
                .FechaActualizacion = FechaFin
            End With
            req.id = Guid.Parse(IdAgencia)
            req.PlantillaClienteServicio = Datos
            res = wsClient.PreFactObtenerPesoVolumenVuelo(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function PreFactObtenerCantVuelosAgencia(IdAgencia As String, FechaInicio As Date, FechaFin As Date) As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New PlantillaClienServRequest
        Dim res As New PlantillaClienServResponse
        Dim Datos As New PlantillaClienServ
        Try
            General.SetBARequest(req)
            With Datos
                .FechaIngreso = FechaInicio
                .FechaActualizacion = FechaFin
            End With
            req.id = Guid.Parse(IdAgencia)
            req.PlantillaClienteServicio = Datos
            res = wsClient.PreFactObtenerCantVuelosAgencia(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function PreFactObtenerPesoVolumenGuia(IdAgencia As String, FechaInicio As Date, FechaFin As Date) As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New PlantillaClienServRequest
        Dim res As New PlantillaClienServResponse
        Dim Datos As New PlantillaClienServ
        Try
            General.SetBARequest(req)
            With Datos
                .FechaIngreso = FechaInicio
                .FechaActualizacion = FechaFin
            End With
            req.id = Guid.Parse(IdAgencia)
            req.PlantillaClienteServicio = Datos
            res = wsClient.PreFactObtenerPesoVolumenGuia(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetSerConsuCliente() As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New ServConsuClienteRequest
        Dim res As New ServConsuClienteResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetSerConsuCliente(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetVuelosGuias(TipoConsulta As Integer, IdAgencia As Guid, Fechaini As Date, FechaFin As Date) As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New VuelosCanceladosRequest
        Dim res As New VuelosCanceladosResponse
        Try
            General.SetBARequest(req)
            With req
                .codigoVuelo = TipoConsulta
                .id = IdAgencia
                .fechaIni = Fechaini
                .fechaFin = FechaFin
            End With

            res = wsClient.GetVuelosGuias(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function PreFactObtenerServConsuCliente(datos As ServConsuCliente) As DataTable
        Dim Result As New DataTable("PreFactObtenerServConsuCliente")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New ServConsuClienteRequest
        Dim res As New ServConsuClienteResponse
        Try
            General.SetBARequest(req)
            req.ServConsuCliente = datos
            res = wsClient.PreFactObtenerServConsuCliente(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function PreFactObtenerPesoVolumenPorBriefGuia(datos As ServConsuCliente) As DataTable
        Dim Result As New DataTable("PreFactObtenerPesoVolumenPorBriefGuia")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New ServConsuClienteRequest
        Dim res As New ServConsuClienteResponse
        Try
            General.SetBARequest(req)
            req.ServConsuCliente = datos
            res = wsClient.PreFactObtenerPesoVolumenPorBriefGuia(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function PreFactObtenerTiempoAlmaceContainer(IdAgencia As String, FechaInicio As Date, FechaFin As Date) As DataTable
        Dim Result As New DataTable("GePeriodicidad")
        Dim wsClient As New FacturacionSoapClient
        Dim req As New PlantillaClienServRequest
        Dim res As New PlantillaClienServResponse
        Dim Datos As New PlantillaClienServ
        Try
            General.SetBARequest(req)
            With Datos
                .FechaIngreso = FechaInicio
                .FechaActualizacion = FechaFin
            End With
            req.id = Guid.Parse(IdAgencia)
            req.PlantillaClienteServicio = Datos
            res = wsClient.PreFactObtenerTiempoAlmaceContainer(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
End Class
