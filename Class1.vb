Public Class Node
    Public value As Integer
    Public left As Node
    Public right As Node

    Public Function getNodeInfo()
        Return value
    End Function

End Class

Public Class BinaryTree

    Public root As Node
    Public Sub New()
        root = Nothing
    End Sub

    Public Sub insert(ByVal newData As String)

        Dim newNode As New Node()
        newNode.value = newData

        If root Is Nothing Then
            root = newNode
        Else
            Dim current As Node = root
            Dim parent As Node
            Do
                parent = current
                If newNode.value < current.value Then
                    current = current.left
                    If (current Is Nothing) Then
                        parent.left = newNode
                        Exit Do
                    End If
                Else
                    current = current.right
                    If current Is Nothing Then
                        parent.right = newNode
                        Exit Do
                    End If
                End If
            Loop
        End If

    End Sub

    Public Function BSearch(ByVal root As Node, value As Integer)

        If (Not (value = root.value)) Then

            If (value < root.value And (Not (root.left Is Nothing))) Then
                BSearch(root.left, value)
            ElseIf (value > root.value And (Not (root.right Is Nothing))) Then
                BSearch(root.right, value)
            End If

            If (root.left Is Nothing And root.right Is Nothing) Then
                Return False

            End If
        Else
            Return True
        End If

    End Function

    Public Sub inOrder(ByVal root As Node)

        If (Not (root Is Nothing)) Then
            inOrder(root.left)
            Console.WriteLine(root.getNodeInfo)
            inOrder(root.right)
        End If

    End Sub

    Public Function removeNode(ByVal root As Node, value As Integer, parent As Node)

        If value < root.value And (Not (root.left Is Nothing)) Then
            removeNode(root.left, value, root)
        ElseIf value < root.value Then
            Return False
        ElseIf value > root.value And (Not (root.right Is Nothing)) Then
            removeNode(root.right, value, root)
        ElseIf value > root.value Then
            Return False
        Else

            If root.left Is Nothing And root.right Is Nothing And root Is parent.left Then
                parent.left = Nothing
                clearNode(root)
            ElseIf root.left Is Nothing And root.right Is Nothing And root Is parent.right Then
                parent.right = Nothing
                clearNode(root)
            ElseIf (Not (root.left Is Nothing)) And root.right Is Nothing And root Is parent.left Then
                parent.left = root.left
                clearNode(root)
            ElseIf (Not (root.left Is Nothing)) And root.right Is Nothing And root Is parent.right Then
                parent.right = root.left
                clearNode(root)
            ElseIf (Not (root.right Is Nothing)) And root.left Is Nothing And root Is parent.left Then
                parent.left = root.right
                clearNode(root)
            ElseIf (Not (root.right Is Nothing)) And root.left Is Nothing And root Is parent.right Then
                parent.right = root.right
                clearNode(root)
            Else
                root.value = getMinValue(root.right)
                removeNode(root.right, root.value, root)
            End If

            Return True
        End If

    End Function

    Public Sub clearNode(root As Node)
        root.value = Nothing
        root.left = Nothing
        root.right = Nothing
    End Sub

    Public Function getMinValue(root As Node) As Integer
        If (Not (root.left Is Nothing)) Then
            getMinValue(root.left)
        Else
            Return root.value
        End If
    End Function

End Class
