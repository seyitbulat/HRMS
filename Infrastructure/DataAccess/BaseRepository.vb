Imports System.Threading.Tasks
Imports Microsoft.EntityFrameworkCore

Public Class BaseRepository(Of T As BaseEntity(Of TKey), TKey, TContext As DbContext)
    Implements IBaseRepository(Of T, TKey)


    Private ReadOnly _context As TContext
    Private ReadOnly _dbSet As DbSet(Of T)

    Public Sub New(context As TContext)
        _context = context
        _dbSet = context.Set(Of T)
    End Sub

    Public Async Function AddAsync(entity As T) As Task(Of T) Implements IBaseRepository(Of T, TKey).AddAsync
        Dim newEntity = Await _context.Set(Of T)().AddAsync(entity)
        Await _context.SaveChangesAsync()
        Return newEntity.Entity
    End Function

    Public Async Function DeleteAsync(id As TKey) As Task Implements IBaseRepository(Of T, TKey).DeleteAsync
        Dim entity = Await _context.Set(Of T)().FindAsync(id)
        If entity IsNot Nothing Then
            _context.Set(Of T)().Remove(entity)
            Await _context.SaveChangesAsync()
        End If
    End Function

    Public Async Function GetAllAsync() As Task(Of IEnumerable(Of T)) Implements IBaseRepository(Of T, TKey).GetAllAsync
        Return Await _context.Set(Of T)().ToListAsync()
    End Function

    Public Async Function GetByIdAsync(id As TKey) As Task(Of T) Implements IBaseRepository(Of T, TKey).GetByIdAsync
        Return Await _context.Set(Of T)().FirstOrDefaultAsync(Function(e) e.Id.Equals(id))
    End Function

    Public Async Function UpdateAsync(entity As T) As Task Implements IBaseRepository(Of T, TKey).UpdateAsync
        _context.Set(Of T)().Update(entity)
        Await _context.SaveChangesAsync()
    End Function
End Class
