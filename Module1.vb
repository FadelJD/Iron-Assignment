


Module Module1


    Function OldPhonePad(ByVal input As String) As String
        Dim keypadMapping As New Dictionary(Of Integer, String) From {
        {1, "&'("},
        {2, "abc"},
        {3, "def"},
        {4, "ghi"},
        {5, "jkl"},
        {6, "mno"},
        {7, "pqrs"},
        {8, "tuv"},
        {9, "wxyz"}
    }

        Dim result As String = ""
        Dim lastKey As Integer = -1
        Dim pressCount As Integer = 0

        For Each ch As Char In input
            If Char.IsDigit(ch) Then
                Dim key As Integer = CInt(ch.ToString())

                If key = lastKey Then
                    pressCount += 1
                Else

                    If lastKey <> -1 Then
                        Dim letters As String = keypadMapping(lastKey)
                        Dim letterIndex As Integer = (pressCount - 1) Mod letters.Length
                        result &= letters(letterIndex)
                    End If
                    lastKey = key
                    pressCount = 1
                End If

            ElseIf ch = " "c Then

                If lastKey <> -1 Then
                    Dim letters As String = keypadMapping(lastKey)
                    Dim letterIndex As Integer = (pressCount - 1) Mod letters.Length
                    result &= letters(letterIndex)
                    lastKey = -1
                    pressCount = 0
                End If

            ElseIf ch = "*"c Then

                If lastKey <> -1 Then
                    Dim letters As String = keypadMapping(lastKey)
                    Dim letterIndex As Integer = (pressCount - 1) Mod letters.Length
                    result &= letters(letterIndex)
                    lastKey = -1
                    pressCount = 0
                End If


                If result.Length > 0 Then
                    result = result.Substring(0, result.Length - 1)
                End If

            ElseIf ch = "#"c Then

                If lastKey <> -1 Then
                    Dim letters As String = keypadMapping(lastKey)
                    Dim letterIndex As Integer = (pressCount - 1) Mod letters.Length
                    result &= letters(letterIndex)
                End If
                Exit For
            End If
        Next

        Return result.ToUpper()
    End Function









    Sub Main()


        Console.WriteLine(OldPhonePad("33#")) ' "E"
        Console.WriteLine(OldPhonePad("227*#")) ' "B"
        Console.WriteLine(OldPhonePad("4433555 555666#")) ' "HELLO"
        Console.WriteLine(OldPhonePad("8 88777444666*664#")) ' "TURING"


        ' Extra test cases: 
        Console.WriteLine(OldPhonePad("244623#")) ' "AHMAD"
        Console.WriteLine(OldPhonePad("888226633*8#")) ' "VBNET"
        Console.WriteLine(OldPhonePad("888226633* 338#")) ' "VBNET" with deletion




        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()

    End Sub


End Module
