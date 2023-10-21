﻿using Anathema.Vectors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Anathema.Vectors.Tests.FloatVectors
{
    public class fvec2SwizzleTests
    {


        [Theory]
        [InlineData(new object[] { 1, 2 })]
        [InlineData(new object[] { 5.2f, 10.00001f })]
        [InlineData(new object[] { -37, 0 })]
        public void swizzles(float x1, float y1)
        {
            fvec2 a = new fvec2(x1, y1);

            Assert.Equal(a.xy.x, a.x);
            Assert.Equal(a.xy.y, a.y);

            Assert.Equal(a.yx.x, a.y);
            Assert.Equal(a.yx.y, a.x);
        }

        [Fact]
        public void swizzleAssign()
        {
            fvec2 a = new fvec2(1, 2);
            Assert.Equal(1, a.x);
            Assert.Equal(2, a.y);

            a.xy = new fvec2(3, 4);
            Assert.Equal(3, a.x);
            Assert.Equal(4, a.y);

            a.yx = new fvec2(6, 5);
            Assert.Equal(5, a.x);
            Assert.Equal(6, a.y);

            fvec2 b = new fvec2(8, 7);
            a.yx = b;
            Assert.Equal(7, a.x);
            Assert.Equal(8, a.y);

        }


        [Fact]
        public void colourSwizzleAssign()
        {
            fvec2 a = new fvec2(1, 2);
            Assert.Equal(1, a.x);
            Assert.Equal(2, a.y);

            a.rg = new fvec2(3, 4);
            Assert.Equal(3, a.x);
            Assert.Equal(4, a.y);

            a.gr = new fvec2(6, 5);
            Assert.Equal(5, a.x);
            Assert.Equal(6, a.y);

            fvec2 b = new fvec2(8, 7);
            a.gr = b;
            Assert.Equal(7, a.x);
            Assert.Equal(8, a.y);
        }




        [Theory]
        [InlineData(new object[] { 1, 2 })]
        [InlineData(new object[] { 5.2f, 10.00001f })]
        [InlineData(new object[] { -37, 0 })]
        public void colourSwizzles(float x1, float y1)
        {
            fvec2 a = new fvec2(x1, y1);

            Assert.Equal(a.rg.r, a.x);
            Assert.Equal(a.rg.g, a.y);

            Assert.Equal(a.gr.r, a.y);
            Assert.Equal(a.gr.g, a.x);
        }
    }
}