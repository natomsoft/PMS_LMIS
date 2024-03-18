Imports System.Data.Objects
Public Class VAL_Utility
    Shared Function Validate(ByVal Value As Object, ByVal ValueName As String, ByRef ERP_ErrorControl As ErrorProvider, ByVal ValidateCriteria As Integer) As Boolean
        Dim ErrorMessage As String = ""
        If ValidateCriteria And VLDTC.Numeric Then If Not IsNumeric(Value) Then ErrorMessage = ErrorMessage & "'" & ValueName & "' Should be numeric value." & vbCrLf
        If ValidateCriteria And VLDTC.NumericGT0 Then If Not Val(Value) <= 0 Then ErrorMessage = ErrorMessage & "'" & ValueName & "' Should be greater than zero." & vbCrLf
        If ValidateCriteria And VLDTC.StringNonEmpty Then If Not Value = String.Empty Then ErrorMessage = ErrorMessage & "'" & ValueName & "' Should be not be empty." & vbCrLf
        If ErrorMessage <> String.Empty Then Return True
        Return False
    End Function
End Class

Enum VLDTC As Int64
    Numeric = 1
    NumericGT0 = 2
    StringNonEmpty = 4
    ExistsInDatabase = 8
End Enum
