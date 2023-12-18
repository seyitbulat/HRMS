Imports System.Threading.Tasks

Public Interface IBaseRepository(Of T, TKey As Structure)
    Function GetAllAsync() As Task(Of IEnumerable(Of T))
    Function GetByIdAsync(id As TKey) As Task(Of T)
    Function AddAsync(entity As T) As Task(Of T)
    Function UpdateAsync(entity As T) As Task(Of T)
    Function DeleteAsync(id As TKey) As Task(Of Boolean)
End Interface
