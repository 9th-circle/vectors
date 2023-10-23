﻿using System;
using Anathema.Vectors.Core;
using Xunit;

namespace Anathema.Vectors.Tests.TemplateVectors
{
    public class tvec4ShortOperatorTests
    {
        [Fact]
        public void negation()
        {
            tvec4<short> a = new tvec4<short>(1, 2, 3, 4);
            tvec4<short> b = -a;

            Assert.Equal(-1, b.x);
            Assert.Equal(-2, b.y);
            Assert.Equal(-3, b.z);
            Assert.Equal(-4, b.w);


            tvec4<string> sa = new tvec4<string>("a", "b", "c", "d");
            Assert.Throws<TypeLoadException>(delegate { tvec4<string> sb = -sa; });
        }
        [Fact]
        public void equality()
        {
            tvec4<short> a = new tvec4<short>(1, 2, 3, 4);
            tvec4<short> b = new tvec4<short>(1, 2, 3, 4);
            tvec4<short> c = new tvec4<short>(3, 4, 5, 6);
            tvec4<short> n = null;
            tvec4<short> n2 = null;
            Assert.True(a == b);
            Assert.False(a == c);
            Assert.False(a != b);
            Assert.True(a != c);
            Assert.False(a == n);
            Assert.False(n == a);
            Assert.True(n == n2);
        }
        [Fact]
        public void equalityInvalid()
        {
            tvec4<string> a = new tvec4<string>("a", "b", "c", "d");
            tvec4<string> b = new tvec4<string>("a", "b", "c", "d");
            Assert.Throws<TypeLoadException>(delegate { var x = a == b; });
        }
        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 15.23f, 20.99999999999f, 0.01f, 10, 12, 1.3 })]
        [InlineData(new object[] { -37, 0, 2, -5, -3, -2, 222, 10 })]
        public void tvec4Addition(short x1, short y1, short z1, short w1, short x2, short y2, short z2, short w2)
        {
            tvec4<short> a = new tvec4<short>(x1, y1, z1, w1);
            tvec4<short> b = new tvec4<short>(x2, y2, z2, w2);

            tvec4<short> c = a + b;
            tvec4<short> d = b + a;

            Assert.Equal(x1 + x2, c.x);
            Assert.Equal(x1 + x2, d.x);
            Assert.Equal(y1 + y2, c.y);
            Assert.Equal(y1 + y2, d.y);
            Assert.Equal(z1 + z2, c.z);
            Assert.Equal(z1 + z2, d.z);
        }

        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 15.23f, 20.99999999999f, 0.01f, 10, 12, 1.3 })]
        [InlineData(new object[] { -37, 0, 2, -5, -3, -2, 222, 10 })]
        public void tvec4Subtraction(short x1, short y1, short z1, short w1, short x2, short y2, short z2, short w2)
        {
            tvec4<short> a = new tvec4<short>(x1, y1, z1, w1);
            tvec4<short> b = new tvec4<short>(x2, y2, z2, w2);

            tvec4<short> c = a - b;
            tvec4<short> d = b - a;

            Assert.Equal(x1 - x2, c.x);
            Assert.Equal(x2 - x1, d.x);
            Assert.Equal(y1 - y2, c.y);
            Assert.Equal(y2 - y1, d.y);
        }

        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 15.23f, 20.99999999999f, 0.01f, 10, 12, 1.3 })]
        [InlineData(new object[] { -37, 0, 2, -5, -3, -2, 222, 10 })]
        public void tvec4Multiplication(short x1, short y1, short z1, short w1, short x2, short y2, short z2, short w2)
        {
            tvec4<short> a = new tvec4<short>(x1, y1, z1, w1);
            tvec4<short> b = new tvec4<short>(x2, y2, z2, w2);
            tvec4<short> c = a * b;
            tvec4<short> d = b * a;

            Assert.Equal(x1 * x2, c.x);
            Assert.Equal(x1 * x2, d.x);
            Assert.Equal(y1 * y2, c.y);
            Assert.Equal(y1 * y2, d.y);
        }
        
        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 15.23f, 20.99999999999f, 0.01f, 10, 12, 1.3 })]
        [InlineData(new object[] { -37, 0, 2, -5, -3, -2, 222, 10 })]
        public void tvec4MutatorMultiplication(short x1, short y1, short z1, short w1, short x2, short y2, short z2, short w2)
        {
            tvec4<short> a = new tvec4<short>(x1, y1, z1, w1);
            tvec4<short> b = new tvec4<short>(x2, y2, z2, w2);

            a *= b;

            Assert.True(x1 * x2 == a.x);
            Assert.True(y1 * y2 == a.y);
        }

        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 15.23f, 20.99999999999f, 1, 10, 12, 1.3 })]
        [InlineData(new object[] { -37, 1, 2, -5, -3, -2, 222, 10 })]
        public void tvec4Division(short x1, short y1, short z1, short w1, short x2, short y2, short z2, short w2)
        {
            tvec4<short> a = new tvec4<short>(x1, y1, z1, w1);
            tvec4<short> b = new tvec4<short>(x2, y2, z2, w2);

            tvec4<short> c = a / b;
            tvec4<short> d = b / a;

            Assert.Equal(x1 / x2, c.x);
            Assert.Equal(y1 / y2, c.y);
            Assert.Equal(x2 / x1, d.x);
            Assert.Equal(y2 / y1, d.y);
        }

        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 20.99999999999f, 2, 123 })]
        [InlineData(new object[] { -37, 0, 2, 1, -33 })]
        public void scalarMultiplication(short x, short y, short z, short w, short scalar)
        {
            tvec4<short> a = new tvec4<short>(x, y, z, w);

            tvec4<short> c = a * scalar;
            tvec4<short> d = scalar * a;

            Assert.Equal(x * scalar, c.x);
            Assert.Equal(x * scalar, d.x);
            Assert.Equal(y * scalar, c.y);
            Assert.Equal(y * scalar, d.y);
        }


        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 20.99999999999f, 2, 123 })]
        [InlineData(new object[] { -37, 1, 2, 1, -33 })]
        public void scalarDivision(short x, short y, short z, short w, short scalar)
        {
            tvec4<short> a = new tvec4<short>(x, y, z, w);

            tvec4<short> c = a / scalar;
            tvec4<short> d = scalar / a;

            Assert.Equal(x / scalar, c.x);
            Assert.Equal(y / scalar, c.y);
            Assert.Equal(scalar / x, d.x);
            Assert.Equal(scalar / y, d.y);
        }

        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 20.99999999999f, 2, 123 })]
        [InlineData(new object[] { -37, 0, 2, 1, -33 })]
        public void scalarAddition(short x, short y, short z, short w, short scalar)
        {
            tvec4<short> a = new tvec4<short>(x, y, z, w);

            tvec4<short> c = a + scalar;
            tvec4<short> d = scalar + a;

            Assert.Equal(x + scalar, c.x);
            Assert.Equal(x + scalar, d.x);
            Assert.Equal(y + scalar, c.y);
            Assert.Equal(y + scalar, d.y);
        }


        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5 })]
        [InlineData(new object[] { 5.2f, 10.00001f, 20.99999999999f, 2, 123 })]
        [InlineData(new object[] { -37, 0, 2, 1, -33 })]
        public void scalarSubtraction(short x, short y, short z, short w, short scalar)
        {
            tvec4<short> a = new tvec4<short>(x, y, z, w);

            tvec4<short> c = a - scalar;
            tvec4<short> d = scalar - a;

            Assert.Equal(x - scalar, c.x);
            Assert.Equal(y - scalar, c.y);
            Assert.Equal(scalar - x, d.x);
            Assert.Equal(scalar - y, d.y);
        }
    }
}
