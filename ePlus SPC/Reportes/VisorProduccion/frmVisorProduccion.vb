Public Class frmVisorProduccion

    Dim muelle1 As String = "Muelle01-PC"
    Dim muelle2 As String = "Muelle02-PC"
    Dim muelle3 As String = "Muelle03-PC"
    Dim muelle4 As String = "Muelle04-PC"
    Dim muelle5 As String = "Muelle05-PC"
    Dim muelle6 As String = "Muelle06-PC"

    Dim dtProcesoMuelleDay As New DataTable("ProcesoMuelleDay")
    Dim dtSumatoriasMes As New DataTable("SumatoriasMes")
    Dim dtSumatoriasAño As New DataTable("SumatoriasAño")

    Dim velocidadMax As Integer = 1578
    Dim velocidadMin As Integer = 0

    Sub RefreshData()
        'Throw New NotImplementedException
    End Sub

    Private Sub frmVisorProduccion_Load(sender As Object, e As EventArgs) Handles Me.Load
        ObtenerDataProceso()
        AsignarValores()
        CalcularVelocidadMuelle()
        bgwConsultaSubtotal.RunWorkerAsync()
        tmrConsultaVelocidad.Enabled = True
    End Sub

    Private Sub ObtenerDataProceso()
        Try
            dtProcesoMuelleDay = CommonProcess.GetSubtotalCargaProcesadaPorDay(Date.Now)
            dtSumatoriasMes = CommonProcess.GetSubtotalCargaProcesadaPorMes(Date.Now)
            dtSumatoriasAño = CommonProcess.GetSubtotalCargaProcesadaPorAño(Date.Now)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub AsignarValores()
        Try
            ValoresDay()
            ValoresMonth()
            ValoresYear()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    
    Private Sub tmrConsultaVelocidad_Tick(sender As Object, e As EventArgs) Handles tmrConsultaVelocidad.Tick
        Try
            bgwConsultaSubtotal.RunWorkerAsync()
            CalcularVelocidadMuelle()
            AsignarValores()
        Catch ex As Exception
            'Errores
        End Try
    End Sub

    Private Sub bgwConsultaSubtotal_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwConsultaSubtotal.DoWork
        ObtenerDataProceso()
    End Sub

    Private Sub CalcularVelocidadMuelle()
        Try
            VelocidadMuelle1()
            VelocidadMuelle2()
            VelocidadMuelle3()
            VelocidadMuelle4()
            VelocidadMuelle5()
            VelocidadMuelle6()
            VelocidadTotal()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VelocidadMuelle1()
        Try
            Dim velocidad As Integer = 0
            Dim piezas As Integer = 0
            Dim hora As Integer = Date.Now.Hour - 1
            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("hora") = hora And r.Item("muelle") = muelle1 Then
                    piezas = r.Item("piezas")
                    Exit For
                End If
            Next
            velocidad = 100 * piezas / velocidadMax
            Dim needle As New Object
            needle = CType(ugMuelle1.Gauges(0), RadialGauge).Scales(0).Markers(0)
            needle.value = velocidad
            CType(ugMuelle1.Gauges(1), DigitalGauge).Text = velocidad
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VelocidadMuelle2()
        Try
            Dim velocidad As Integer = 0
            Dim piezas As Integer = 0
            Dim hora As Integer = Date.Now.Hour
            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("hora") = hora And r.Item("muelle") = muelle2 Then
                    piezas = r.Item("piezas")
                    Exit For
                End If
            Next
            velocidad = 100 * piezas / velocidadMax
            Dim needle As New Object
            needle = CType(ugMuelle2.Gauges(0), RadialGauge).Scales(0).Markers(0)
            needle.value = velocidad
            CType(ugMuelle2.Gauges(1), DigitalGauge).Text = velocidad
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VelocidadMuelle3()
        Try
            Dim velocidad As Integer = 0
            Dim piezas As Integer = 0
            Dim hora As Integer = Date.Now.Hour - 1
            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("hora") = hora And r.Item("muelle") = muelle3 Then
                    piezas = r.Item("piezas")
                    Exit For
                End If
            Next
            velocidad = 100 * piezas / velocidadMax
            Dim needle As New Object
            needle = CType(ugMuelle3.Gauges(0), RadialGauge).Scales(0).Markers(0)
            needle.value = velocidad
            CType(ugMuelle3.Gauges(1), DigitalGauge).Text = velocidad
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VelocidadMuelle4()
        Try
            Dim velocidad As Integer = 0
            Dim piezas As Integer = 0
            Dim hora As Integer = Date.Now.Hour - 1
            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("hora") = hora And r.Item("muelle") = muelle4 Then
                    piezas = r.Item("piezas")
                    Exit For
                End If
            Next
            velocidad = 100 * piezas / velocidadMax
            Dim needle As New Object
            needle = CType(ugMuelle4.Gauges(0), RadialGauge).Scales(0).Markers(0)
            needle.value = velocidad
            CType(ugMuelle4.Gauges(1), DigitalGauge).Text = velocidad
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VelocidadMuelle5()
        Try
            Dim velocidad As Integer = 0
            Dim piezas As Integer = 0
            Dim hora As Integer = Date.Now.Hour - 1
            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("hora") = hora And r.Item("muelle") = muelle5 Then
                    piezas = r.Item("piezas")
                    Exit For
                End If
            Next
            velocidad = 100 * piezas / velocidadMax
            Dim needle As New Object
            needle = CType(ugMuelle5.Gauges(0), RadialGauge).Scales(0).Markers(0)
            needle.value = velocidad
            CType(ugMuelle5.Gauges(1), DigitalGauge).Text = velocidad
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VelocidadMuelle6()
        Try
            Dim velocidad As Integer = 0
            Dim piezas As Integer = 0
            Dim hora As Integer = Date.Now.Hour - 1
            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("hora") = hora And r.Item("muelle") = muelle6 Then
                    piezas = r.Item("piezas")
                    Exit For
                End If
            Next
            velocidad = 100 * piezas / velocidadMax
            Dim needle As New Object
            needle = CType(ugMuelle6.Gauges(0), RadialGauge).Scales(0).Markers(0)
            needle.value = velocidad
            CType(ugMuelle6.Gauges(1), DigitalGauge).Text = velocidad
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VelocidadTotal()
        Try
            Dim velocidad As Integer = 0
            Dim piezas As Integer = 0
            Dim hora As Integer = Date.Now.Hour - 1
            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("hora") = hora And (r.Item("muelle") = muelle1 Or r.Item("muelle") = muelle2 Or r.Item("muelle") = muelle3 Or r.Item("muelle") = muelle4 Or r.Item("muelle") = muelle5 Or r.Item("muelle") = muelle6) Then
                    piezas += r.Item("piezas")
                End If
            Next
            velocidad = 100 * piezas / velocidadMax
            upbTotal.Value = velocidad
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ValoresDay()
        Dim piezasM1 As Integer = 0
        Dim pesoM1 As Double = 0D
        Dim volumenM1 As Double = 0D

        Dim piezasM2 As Integer = 0
        Dim pesoM2 As Double = 0D
        Dim volumenM2 As Double = 0D

        Dim piezasM3 As Integer = 0
        Dim pesoM3 As Double = 0D
        Dim volumenM3 As Double = 0D

        Dim piezasM4 As Integer = 0
        Dim pesoM4 As Double = 0D
        Dim volumenM4 As Double = 0D

        Dim piezasM5 As Integer = 0
        Dim pesoM5 As Double = 0D
        Dim volumenM5 As Double = 0D

        Dim piezasM6 As Integer = 0
        Dim pesoM6 As Double = 0D
        Dim volumenM6 As Double = 0D

        Try
            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("muelle") = muelle1 Then
                    piezasM1 += r.Item("piezas")
                    pesoM1 += r.Item("peso")
                    volumenM1 += r.Item("volumen")
                End If
            Next

            uneMuelle1ProPieHoy.Value = piezasM1
            uneMuelle1ProPeHoy.Value = pesoM1
            uneMuelle1ProVoHoy.Value = volumenM1

            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("muelle") = muelle2 Then
                    piezasM2 += r.Item("piezas")
                    pesoM2 += r.Item("peso")
                    volumenM2 += r.Item("volumen")
                End If
            Next

            uneMuelle2ProPieHoy.Value = piezasM2
            uneMuelle2ProPeHoy.Value = pesoM2
            uneMuelle2ProVoHoy.Value = volumenM2

            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("muelle") = muelle3 Then
                    piezasM3 += r.Item("piezas")
                    pesoM3 += r.Item("peso")
                    volumenM3 += r.Item("volumen")
                End If
            Next

            uneMuelle3ProPieHoy.Value = piezasM3
            uneMuelle3ProPeHoy.Value = pesoM3
            uneMuelle3ProVoHoy.Value = volumenM3

            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("muelle") = muelle4 Then
                    piezasM4 += r.Item("piezas")
                    pesoM4 += r.Item("peso")
                    volumenM4 += r.Item("volumen")
                End If
            Next

            uneMuelle4ProPieHoy.Value = piezasM4
            uneMuelle4ProPeHoy.Value = pesoM4
            uneMuelle4ProVoHoy.Value = volumenM4

            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("muelle") = muelle5 Then
                    piezasM5 += r.Item("piezas")
                    pesoM5 += r.Item("peso")
                    volumenM5 += r.Item("volumen")
                End If
            Next

            uneMuelle5ProPieHoy.Value = piezasM5
            uneMuelle5ProPeHoy.Value = pesoM5
            uneMuelle5ProVoHoy.Value = volumenM5

            For Each r As DataRow In dtProcesoMuelleDay.Rows
                If r.Item("muelle") = muelle6 Then
                    piezasM6 += r.Item("piezas")
                    pesoM6 += r.Item("peso")
                    volumenM6 += r.Item("volumen")
                End If
            Next

            uneMuelle6ProPieHoy.Value = piezasM6
            uneMuelle6ProPeHoy.Value = pesoM6
            uneMuelle6ProVoHoy.Value = volumenM6


            uneTotProPieHoy.Value = dtProcesoMuelleDay.Compute("Sum(piezas)", "").ToString()
            uneTotProPeHoy.Value = dtProcesoMuelleDay.Compute("Sum(peso)", "").ToString()
            uneTotProVoHoy.Value = dtProcesoMuelleDay.Compute("Sum(volumen)", "").ToString()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ValoresMonth()
        Try
            For Each r As DataRow In dtSumatoriasMes.Rows
                Select Case r.Item("muelle")
                    Case muelle1
                        uneMuelle1ProPieMes.Value = r.Item("piezas")
                        uneMuelle1ProPeMes.Value = r.Item("peso")
                        uneMuelle1ProVoMes.Value = r.Item("volumen")
                    Case muelle2
                        uneMuelle2ProPieMes.Value = r.Item("piezas")
                        uneMuelle2ProPeMes.Value = r.Item("peso")
                        uneMuelle2ProVoMes.Value = r.Item("volumen")
                    Case muelle3
                        uneMuelle3ProPieMes.Value = r.Item("piezas")
                        uneMuelle3ProPeMes.Value = r.Item("peso")
                        uneMuelle3ProVoMes.Value = r.Item("volumen")
                    Case muelle4
                        uneMuelle4ProPieMes.Value = r.Item("piezas")
                        uneMuelle4ProPeMes.Value = r.Item("peso")
                        uneMuelle4ProVoMes.Value = r.Item("volumen")
                    Case muelle5
                        uneMuelle5ProPieMes.Value = r.Item("piezas")
                        uneMuelle5ProPeMes.Value = r.Item("peso")
                        uneMuelle5ProVoMes.Value = r.Item("volumen")
                    Case muelle6
                        uneMuelle6ProPieMes.Value = r.Item("piezas")
                        uneMuelle6ProPeMes.Value = r.Item("peso")
                        uneMuelle6ProVoMes.Value = r.Item("volumen")
                End Select
            Next
            uneTotProPieMes.Value = dtSumatoriasMes.Compute("Sum(piezas)", "").ToString()
            uneTotProPeMes.Value = dtSumatoriasMes.Compute("Sum(peso)", "")
            uneTotProVoMes.Value = dtSumatoriasMes.Compute("Sum(volumen)", "").ToString()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ValoresYear()
        Try
            For Each r As DataRow In dtSumatoriasAño.Rows
                Select Case r.Item("muelle")
                    Case muelle1
                        uneMuelle1ProPieAño.Value = r.Item("piezas")
                        uneMuelle1ProPeAño.Value = r.Item("peso")
                        uneMuelle1ProVoAño.Value = r.Item("volumen")
                    Case muelle2
                        uneMuelle2ProPieAño.Value = r.Item("piezas")
                        uneMuelle2ProPeAño.Value = r.Item("peso")
                        uneMuelle2ProVoAño.Value = r.Item("volumen")
                    Case muelle3
                        uneMuelle3ProPieAño.Value = r.Item("piezas")
                        uneMuelle3ProPeAño.Value = r.Item("peso")
                        uneMuelle3ProVoAño.Value = r.Item("volumen")
                    Case muelle4
                        uneMuelle4ProPieAño.Value = r.Item("piezas")
                        uneMuelle4ProPeAño.Value = r.Item("peso")
                        uneMuelle4ProVoAño.Value = r.Item("volumen")
                    Case muelle5
                        uneMuelle5ProPieAño.Value = r.Item("piezas")
                        uneMuelle5ProPeAño.Value = r.Item("peso")
                        uneMuelle5ProVoAño.Value = r.Item("volumen")
                    Case muelle6
                        uneMuelle6ProPieAño.Value = r.Item("piezas")
                        uneMuelle6ProPeAño.Value = r.Item("peso")
                        uneMuelle6ProVoAño.Value = r.Item("volumen")
                End Select
            Next
            uneTotProPieAño.Value = dtSumatoriasAño.Compute("Sum(piezas)", "").ToString()
            uneTotProPeAño.Value = dtSumatoriasAño.Compute("Sum(peso)", "")
            uneTotProVoAño.Value = dtSumatoriasAño.Compute("Sum(volumen)", "")
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class