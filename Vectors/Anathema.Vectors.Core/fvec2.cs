﻿#if FLOATS_ENABLED
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anathema.Vectors.Core
{
    /// <summary>
    /// A single-precision floating point, 2-component vector.
    /// </summary>
    public class fvec2
    {
        ///////////////////////////
        //        Members        //
        ///////////////////////////

        public float x { get; set; }
        public float y { get; set; }


        ///////////////////////////
        //     Constructors      //
        ///////////////////////////

        public fvec2()
        {
        }

        public fvec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public fvec2(fvec2 xy)
        {
            x = xy.x;
            y = xy.y;
        }
        public fvec2(dvec2 xy)
        {
            x = (float)xy.x;
            y = (float)xy.y;
        }

        ///////////////////////////
        //      Conversions      //
        ///////////////////////////


        public static fvec2 fromAngle(float angle)
        {
            return new fvec2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }
        public static fvec2 fromAngleAndLength(float angle, float length)
        {
            return new fvec2((float)Math.Cos(angle) * length, (float)Math.Sin(angle) * length);
        }


        ///////////////////////////
        //      Derivations      //
        ///////////////////////////


        public float angleRadians
        {
            get
            {
                return (float)Math.Atan2(y, x);
            }
        }
        public float angleDegrees
        {
            get
            {
                return angleRadians * (180.0f / (float)Math.PI);
            }
        }

        public virtual float length
        {
            get
            {
                return (float)Math.Sqrt((x * x) + (y * y));
            }
        }
        public fvec2 normalised
        {
            get
            {
                return this / length;
            }
        }


        ///////////////////////////
        //       Mutators        //
        ///////////////////////////

        public virtual void normalise()
        {
            float f = length;
            x /= f;
            y /= f;
        }

        ///////////////////////////
        //        Swizzles       //
        ///////////////////////////
#if SWIZZLES_ENABLED
        public fvec2 xy
        {
            get
            {
                return new fvec2(x, y);
            }
            set
            {
                x = value.x;
                y = value.y;
            }
        }
        public fvec2 yx
        {
            get
            {
                return new fvec2(y, x);
            }
            set
            {
                y = value.x;
                x = value.y;
            }
        }
#endif

        ///////////////////////////
        //       Operators       //
        ///////////////////////////


        public fvec2 dot(fvec2 b)
        {
            return dot(this, b);
        }
        public static fvec2 dot(fvec2 a, fvec2 b)
        {
            return a * b;
        }

        public fvec2 cross()
        {
            return cross(this);
        }
        public static fvec2 cross(fvec2 a)
        {
            return new fvec2(a.y, a.x);
        }


        public static bool operator !=(fvec2 a, fvec2 b)
        {
            return !(a == b);
        }
        public static bool operator ==(fvec2 a, fvec2 b)
        {
            return scalar.isClose(a.x, b.x) && scalar.isClose(a.y, b.y);
        }

        public static fvec2 operator *(fvec2 a, fvec2 b)
        {
            return new fvec2(a.x * b.x, a.y * b.y);
        }
        public static fvec2 operator /(fvec2 a, fvec2 b)
        {
            return new fvec2(a.x / b.x, a.y / b.y);
        }
        public static fvec2 operator +(fvec2 a, fvec2 b)
        {
            return new fvec2(a.x + b.x, a.y + b.y);
        }
        public static fvec2 operator -(fvec2 a, fvec2 b)
        {
            return new fvec2(a.x - b.x, a.y - b.y);
        }



        public static fvec2 operator *(fvec2 a, float b)
        {
            return new fvec2(a.x * b, a.y * b);
        }
        public static fvec2 operator /(fvec2 a, float b)
        {
            return new fvec2(a.x / b, a.y / b);
        }
        public static fvec2 operator +(fvec2 a, float b)
        {
            return new fvec2(a.x + b, a.y + b);
        }
        public static fvec2 operator -(fvec2 a, float b)
        {
            return new fvec2(a.x - b, a.y - b);
        }



        public static fvec2 operator *(float b, fvec2 a)
        {
            return new fvec2(a.x * b, a.y * b);
        }
        public static fvec2 operator /(float b, fvec2 a)
        {
            return new fvec2(a.x / b, a.y / b);
        }
        public static fvec2 operator +(float b, fvec2 a)
        {
            return new fvec2(a.x + b, a.y + b);
        }
        public static fvec2 operator -(float b, fvec2 a)
        {
            return new fvec2(a.x - b, a.y - b);
        }
        public static fvec2 operator -(fvec2 a)
        {
            return new fvec2(-a.x, -a.y);
        }


        public static fvec2 operator *(fvec2 a, fmat2 b)
        {
            return new fvec2((a.x * b.getValue(0, 0)) + (a.y * b.getValue(0, 1)),
                                (a.x * b.getValue(1, 0)) + (a.y * b.getValue(1, 1)));
        }
        public static fvec2 operator *(fmat2 b, fvec2 a)
        {
            return a * b.transposed;
        }
        public static dvec2 operator *(fvec2 a, dmat2 b)
        {
            return new dvec2((a.x * b.getValue(0, 0)) + (a.y * b.getValue(0, 1)),
                                (a.x * b.getValue(1, 0)) + (a.y * b.getValue(1, 1)));
        }
        public static dvec2 operator *(dmat2 b, fvec2 a)
        {
            return a * b.transposed;
        }

#if NESTING_ENABLED
        public static fvec2 operator *(fvec2 a, tvec2<tvec2<float>> b)
        {
            fmat2 matrix = fmat2.fromNestedVector(b);

            return a * matrix;
        }
        public static fvec2 operator *(tvec2<tvec2<float>> b, fvec2 a)
        {
            fmat2 matrix = fmat2.fromNestedVector(b);

            return a * matrix.transposed;
        }

#endif
        public float this[int i]
        {
            get
            {
                if (i == 0)
                    return x;
                if (i == 1)
                    return y;
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (i == 0)
                { x = value; return; }
                if (i == 1)
                { y = value; return; }
                throw new IndexOutOfRangeException();
            }
        }
    }
}
#endif