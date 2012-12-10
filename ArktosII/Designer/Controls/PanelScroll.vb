Namespace Designer.Controls

    Public Class PanelScroll
        Inherits Panel

#Region " Constructor "

        Public Sub New()
            MyBase.New()
        End Sub

#End Region

#Region " Implementation Members "

#Region " Events "

        Public Event HScrollValueChanged As ScrollEventHandler
        Public Event VScrollValueChanged As ScrollEventHandler

#End Region

        Private Const WM_HSCROLL As Integer = &H114
        Private Const WM_VSCROLL As Integer = &H115

        Private Shared myEvents() As ScrollEventType = New ScrollEventType() { _
            ScrollEventType.SmallDecrement, _
            ScrollEventType.SmallIncrement, _
            ScrollEventType.LargeDecrement, _
            ScrollEventType.LargeIncrement, _
            ScrollEventType.ThumbPosition, _
            ScrollEventType.ThumbTrack, _
            ScrollEventType.First, _
            ScrollEventType.Last, _
            ScrollEventType.EndScroll _
        }

#End Region

#Region " Overrides "

        Protected Overrides Sub WndProc(ByRef m As Message)
            ' Let the control process the message
            MyBase.WndProc(m)

            ' Was this a horizontal scroll message?
            If m.Msg = WM_HSCROLL Then
                Dim wParam As Int32 = m.WParam.ToInt32

                OnHScrollValueChanged(New ScrollEventArgs(GetEventType(wParam And &HFFFF), CInt(wParam >> 16)))
            ElseIf m.Msg = WM_VSCROLL Then
                Dim wParam As Int32 = m.WParam.ToInt32

                OnVScrollValueChanged(New ScrollEventArgs(GetEventType(wParam And &HFFFF), CInt(wparam >> 16)))
            End If

        End Sub

#End Region

#Region " Private Functions "

        Private Function GetEventType(ByVal wParam As Int32) As ScrollEventType
            If wParam < myEvents.Length Then
                Return myEvents(wParam)
            Else
                Return ScrollEventType.EndScroll
            End If
        End Function

#End Region

#Region " Protected Functions "

        Protected Overridable Sub OnHScrollValueChanged(ByVal e As ScrollEventArgs)
            RaiseEvent HScrollValueChanged(Me, e)
        End Sub

        Protected Overridable Sub OnVScrollValueChanged(ByVal e As ScrollEventArgs)
            RaiseEvent VScrollValueChanged(Me, e)
        End Sub

#End Region

    End Class

End Namespace