
'Imports IS_NTC_ControlLibrary

Public NotInheritable Class AboutSoftware
    'Dim textStyle As New TextStyle

    Private Sub AboutSoftware_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        'Me.TextBoxDescription.Text = My.Application.Info.Description
        Me.TextBoxDescription.Text = SoftwareDescription
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private ReadOnly Property SoftwareDescription() As String
        Get
            Dim objStringBuilder As New System.Text.StringBuilder
            'objStringBuilder.AppendLine("SOFTWARE DESCRIPTION: ")

            objStringBuilder.AppendLine("SOFTWARE DESCRIPTION: Information management system developed for Store Department in Nepal Telecom, BRANCH-Pokhara,Ranipauwa")
            objStringBuilder.AppendLine("LANGUAGE: Visual Basic.NET  ")
            objStringBuilder.AppendLine("DATABASE ENGINE: Microsoft Access ")
            objStringBuilder.AppendLine("PLATFORM: Microsoft Visual Studio 2013")
            Return objStringBuilder.ToString
        End Get
    End Property

End Class
