'Shaw_Doyle
'RCET0265
'Fall 2020
'Math Contest
'https://github.com/shawdoyl/MathContest

Public Class MathContest
    Dim numberOfProblems As Integer = 0
    Dim numberOfProblemsCorrect As Integer = 0
    Dim studentAge As Integer
    Dim studentGrade As Integer
    Dim firstNumber As Integer
    Dim secondNumber As Integer
    Dim studentAnswer As Integer
    Dim actualAnswer As Integer
    Dim studentName As String = ""

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        Dim userMessage As String
        Dim firstName() As String

        firstName = Split(studentName)

        If AddRadioButton.Checked = True Then
            actualAnswer = CInt(firstNumber) + CInt(secondNumber)
        ElseIf SubtractRadioButton.Checked = True Then
            actualAnswer = CInt(firstNumber) - CInt(secondNumber)
        ElseIf DivideRadioButton.Checked = True Then
            actualAnswer = CInt(firstNumber) / CInt(secondNumber)
        ElseIf MultiplyRadioButton.Checked = True Then
            actualAnswer = CInt(firstNumber) * CInt(secondNumber)
        End If

        If CInt(AnswerTextBox.Text) = CInt(actualAnswer) Then
            My.Computer.Audio.Play(My.Resources.Resource1.applause2,
            AudioPlayMode.Background)
            userMessage = "Good job " & firstName(0) & ", that is correct!"
            numberOfProblemsCorrect += 1
        Else
            userMessage = "Sorry " & firstName(0) & ", that is not correct. The correct " _
                        & "answer was " & actualAnswer & "."
        End If

        MsgBox(userMessage)
        Randomize()
        firstNumber = CInt((12 * Rnd()) + 1)
        Randomize()
        secondNumber = CInt((12 * Rnd()) + 1)
        FirstNumberTextBox.Text = firstNumber
        SecondNumberTextBox.Text = secondNumber
        AnswerTextBox.Text = ""
        SummaryButton.Enabled = True
        numberOfProblems += 1
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        numberOfProblems = 0
        numberOfProblemsCorrect = 0
        NameTextBox.Text = ""
        GradeTextBox.Text = ""
        AgeTextBox.Text = ""
        AnswerTextBox.Text = ""
        FirstNumberTextBox.Text = ""
        SecondNumberTextBox.Text = ""
        ResetAllControls()
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        MsgBox("You got " & numberOfProblemsCorrect & " answers correct out of all possible " & numberOfProblems)
    End Sub

    Private Sub MathContest_Load(sender As Object, e As EventArgs) Handles Me.Load
        ResetAllControls()
    End Sub

    Sub ResetAllControls()
        AddRadioButton.Enabled = False
        SubtractRadioButton.Enabled = False
        MultiplyRadioButton.Enabled = False
        DivideRadioButton.Enabled = False
        SubmitButton.Enabled = False
        SummaryButton.Enabled = False
        FirstNumberTextBox.Enabled = False
        SecondNumberTextBox.Enabled = False
        AnswerTextBox.Enabled = False
        AddRadioButton.Checked = True
        NameTextBox.Enabled = True
        AgeTextBox.Enabled = True
        GradeTextBox.Enabled = True
        ValidateButton.Enabled = True
    End Sub

    Private Sub ValidateClick(sender As Object, e As EventArgs) Handles ValidateButton.Click
        Dim userMessage As String = ""
        Dim AgeBad As Boolean = False
        Dim GradeBad As Boolean = False

        If NameTextBox.Text = "" Then
            userMessage = "Please enter the students name." & vbNewLine
        Else
            studentName = NameTextBox.Text
        End If

        Try
            studentAge = CInt(AgeTextBox.Text)
            If studentAge > 6 And studentAge < 12 Then
            Else
                userMessage &= "Sorry, only students that are between 7 and 11 may compete" & vbNewLine
            End If
        Catch ex As Exception
            userMessage &= "Please enter a valid age" & vbNewLine
            AgeBad = True
        End Try
        Try
            studentGrade = CInt(GradeTextBox.Text)
            If studentGrade > 0 And studentGrade < 5 Then
            Else
                userMessage &= "Sorry, only students that are in grades 1 through 4 may compete" & vbNewLine
            End If
        Catch ex As Exception
            userMessage &= "Please enter a valid grade" & vbNewLine
            GradeBad = True
        End Try
        If userMessage <> "" Then
            MsgBox(userMessage)
            If AgeBad = True Then
                AgeTextBox.Text = ""
            End If
            If GradeBad = True Then
                GradeTextBox.Text = ""
            End If
            If NameTextBox.Text = "" Then
                NameTextBox.Select()
            ElseIf AgeBad = True Then
                AgeTextBox.Select()
            ElseIf GradeBad = True Then
                GradeTextBox.Select()
            End If
        Else
            AddRadioButton.Enabled = True
            SubtractRadioButton.Enabled = True
            MultiplyRadioButton.Enabled = True
            DivideRadioButton.Enabled = True
            FirstNumberTextBox.Enabled = True
            SecondNumberTextBox.Enabled = True
            AnswerTextBox.Enabled = True
            NameTextBox.Enabled = False
            AgeTextBox.Enabled = False
            GradeTextBox.Enabled = False
            ValidateButton.Enabled = False
            Randomize()
            firstNumber = CInt((12 * Rnd()) + 1)
            Randomize()
            secondNumber = CInt((12 * Rnd()) + 1)
            FirstNumberTextBox.Text = firstNumber
            SecondNumberTextBox.Text = secondNumber
        End If
    End Sub

    Private Sub AnyNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles FirstNumberTextBox.TextChanged, SecondNumberTextBox.TextChanged, AnswerTextBox.TextChanged
        Dim userMessage As String = ""
        Dim AnswerGood As Boolean
        AnswerGood = False

        If AnswerTextBox.Text <> "" Then
            Try
                AnswerGood = True
            Catch ex As Exception
                MsgBox("Please enter a valid answer")
            End Try
        End If

        If userMessage <> "" Then
            MsgBox(userMessage)
        Else
        End If
        If AnswerGood = True Then
            SubmitButton.Enabled = True
        Else
            SubmitButton.Enabled = False
        End If
    End Sub

End Class
