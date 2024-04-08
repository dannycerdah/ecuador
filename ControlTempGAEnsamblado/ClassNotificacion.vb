Public Class ClassNotificacion
    Public Shared Function ProcesaNotificacion(Asunto As String, CuerpoCorreo As String, Destinatarios As String, Optional ByVal StartupPath As String = "") As String
        Dim result As String = String.Empty
        Try
            Dim DtRegCuartProduc As New DataTable("DtRegCuartProduc")
            DtRegCuartProduc = CommonDataTempera.ObtenerRegCuartProduc()
            Dim DtViewRegCuartProduc As New DataView(DtRegCuartProduc)
            Dim DataProducto As DataTable
            Dim _CuerpoCorreo As String = CuerpoCorreo
            If DtRegCuartProduc.Rows.Count > 0 Then
                Dim DtTempAct As New DataTable("DtTempAct")
                DtTempAct = CommonDataTempera.ObtenerTempAct("")
                DataProducto = DtViewRegCuartProduc.ToTable(True, "idProducto")
                Dim rowsCuartos As DataRow()
                Dim rowsTemp As DataRow()
                Dim CuartoFrio As String
                Dim _CuartoFrio As String
                Dim TempC As Decimal
                Dim Cuarto As String
                Dim Producto As String
                Dim Guias As String
                Dim SortOrder As String = "RegCargaCuartoFrio ASC"
                Dim EvnioPendiente As Integer
                For Each rows As DataRow In DataProducto.Rows
                    rowsCuartos = DtRegCuartProduc.Select("idProducto='" + rows.Item("idProducto").ToString() + "'", SortOrder)
                    Producto = String.Empty
                    Guias = "<ul><li>"
                    TempC = 0D
                    CuartoFrio = String.Empty
                    _CuartoFrio = String.Empty
                    Cuarto = String.Empty
                    EvnioPendiente = 0
                    For Each rows2 As DataRow In rowsCuartos
                        Select Case rows2.Item(2)
                            Case "A2"
                                CuartoFrio = "CUARTO-FRIO-A-2"
                            Case "A3-4"
                                CuartoFrio = "CUARTO-FRIO-A-3-4"
                            Case "A5"
                                CuartoFrio = "CUARTO-FRIO-A-5"
                            Case "B"
                                CuartoFrio = "CUARTO-FRIO-B-1"
                            Case Else
                                CuartoFrio = String.Empty
                                Continue For
                        End Select
                        If Cuarto = String.Empty Then
                            Cuarto = rows2.Item(2)
                        End If
                        If Cuarto = rows2.Item(2) Then
                            rowsTemp = DtTempAct.Select("NombreCuartoFrio='" + CuartoFrio + "'")
                            For Each rows3 As DataRow In rowsTemp
                                If rows3.Item(4) > rows2.Item(4) Or rows3.Item(4) < rows2.Item(5) Then
                                    Guias = Guias & rows2.Item(1) & "</li><li>"
                                    _CuartoFrio = CuartoFrio
                                    TempC = rows3.Item(4)
                                    Producto = rows2.Item(3)
                                    EvnioPendiente = 1
                                End If
                            Next
                        Else
                            If Producto <> String.Empty Then
                                Guias = Guias & "</li></ul>"
                                _CuerpoCorreo = _CuerpoCorreo.Replace("(producto)", Producto)
                                _CuerpoCorreo = _CuerpoCorreo.Replace("(Guias)", Guias)
                                _CuerpoCorreo = _CuerpoCorreo.Replace("(cuartofrio)", _CuartoFrio)
                                _CuerpoCorreo = _CuerpoCorreo.Replace("(temp)", Decimal.Round(TempC, 2).ToString.Replace(",", "."))
                                _CuerpoCorreo = _CuerpoCorreo.Replace("<li></li>", "")
                                ErrorManager.SendCorreoAdjunto(_CuerpoCorreo, "", Destinatarios, Asunto, False, "")
                                _CuerpoCorreo = CuerpoCorreo
                                EvnioPendiente = 0
                            End If
                            Guias = "<ul><li>"
                            rowsTemp = DtTempAct.Select("NombreCuartoFrio='" + CuartoFrio + "'")
                            For Each rows3 As DataRow In rowsTemp
                                If rows3.Item(4) > rows2.Item(4) Or rows3.Item(4) < rows2.Item(5) Then
                                    Guias = Guias & rows2.Item(1) & "</li><li>"
                                    _CuartoFrio = CuartoFrio
                                    TempC = rows3.Item(4)
                                    Producto = rows2.Item(3)
                                    EvnioPendiente = 1
                                End If
                            Next
                            Cuarto = rows2.Item(2)
                        End If
                    Next
                    If EvnioPendiente = 1 Then
                        If Producto <> String.Empty Then
                            Guias = Guias & "</li></ul>"
                            _CuerpoCorreo = _CuerpoCorreo.Replace("(producto)", Producto)
                            _CuerpoCorreo = _CuerpoCorreo.Replace("(Guias)", Guias)
                            _CuerpoCorreo = _CuerpoCorreo.Replace("(cuartofrio)", _CuartoFrio)
                            _CuerpoCorreo = _CuerpoCorreo.Replace("(temp)", Decimal.Round(TempC, 2).ToString.Replace(",", "."))
                            _CuerpoCorreo = _CuerpoCorreo.Replace("<li></li>", "")
                            ErrorManager.SendCorreoAdjunto(_CuerpoCorreo, "", Destinatarios, Asunto, False, "")
                            _CuerpoCorreo = CuerpoCorreo
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            result = ex.Message
            ErrorManager.SetLogEvent(ex, StartupPath)
        End Try
        Return result
    End Function
End Class


