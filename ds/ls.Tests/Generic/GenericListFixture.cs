using System.Collections.Generic;
using ls.Generic;
using NUnit.Framework;

namespace ls.Tests.Generic
{
    [TestFixture]
    public class GenericListFixture
    {
        [Test]
        public void AppendLast_AddsNodeToLast()
        {
            
            var gl = new GenericList<int>();
            gl.AppendLast(100);
            gl.AppendLast(120);
            gl.AppendLast(130);

            var list = gl.ToList();
            Assert.AreEqual(100, list[0]);
            Assert.AreEqual(120, list[1]);
            Assert.AreEqual(130, list[2]);
        }
    }
}
