using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            
            Assert.Equal(42,x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            
            Assert.Equal("NEW NAME", book1.Name);
            
        }

        private void GetBookSetName(ref InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }
        
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("BOOK 1", book1.Name);
            
        }

        private void GetBookSetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }
        
        
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            Assert.Equal("NEW NAME", book1.Name);
            
        }

        private void SetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper =  MakeUpperCase(name);
            
            Assert.Equal("Scott",name);
            Assert.Equal("SCOTT",upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("BOOK 1", book1.Name);
            Assert.Equal("BOOK 2", book2.Name);
            Assert.NotSame(book1,book2);
        }
        
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name); 
        }
    }
}
