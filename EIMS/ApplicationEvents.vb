Namespace My
    Partial Friend Class myapplication
        Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

            ' Set the display time to 5000 milliseconds (5 seconds). 

            Me.MinimumSplashScreenDisplayTime = 5000

            Return MyBase.OnInitialize(commandLineArgs)

        End Function
    End Class






End Namespace