using FunSignalR.Shared.Enums;
using FunSignalR.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSignalR.Test
{
    public class ExtensionClass_Test
    {
        [Fact]
        public void Test1()
        {
            var result = EnumExtension.GetDescriptions<ShapeType>().ToList();

            Assert.Equal(result[0], "Circle");
        }
    }
}
