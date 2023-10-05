﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.Core
{
    /// <summary>
    /// A double precision floating point, 2-component vector.
    /// </summary>
    public class dvec2
    {
        ///////////////////////////
        //        Members        //
        ///////////////////////////

        public double x { get; set; }
        public double y { get; set; }


        ///////////////////////////
        //     Constructors      //
        ///////////////////////////

        public dvec2()
        {
        }

        public dvec2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public dvec2(dvec2 xy)
        {
            x = xy.x;
            y = xy.y;
        }
        public dvec2(ifvec2 xy)
        {
            x = xy.x;
            y = xy.y;
        }

        ///////////////////////////
        //      Conversions      //
        ///////////////////////////


        public static dvec2 fromAngle(double angle)
        {
            return new dvec2(Math.Cos(angle), Math.Sin(angle));
        }
        public static dvec2 fromAngleAndLength(double angle, double length)
        {
            return new dvec2(Math.Cos(angle) * length, Math.Sin(angle) * length);
        }

        ///////////////////////////
        //      Derivations      //
        ///////////////////////////


        public double angleRadians
        {
            get
            {
                return Math.Atan2(y, x);
            }
        }
        public double angleDegrees
        {
            get
            {
                return angleRadians * (180.0f / Math.PI);
            }
        }

        public virtual double length
        {
            get
            {
                return Math.Sqrt((x * x) + (y * y));
            }
        }
        public dvec2 normalised
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
            double f = length;
            x /= f;
            y /= f;
        }

        ///////////////////////////
        //        Swizzles       //
        ///////////////////////////

        public dvec2 xy
        {
            get
            {
                return new dvec2(x, y);
            }
            set
            {
                x = value.x;
                y = value.y;
            }
        }
        public dvec2 yx
        {
            get
            {
                return new dvec2(y, x);
            }
            set
            {
                y = value.x;
                x = value.y;
            }
        }


        ///////////////////////////
        //       Operators       //
        ///////////////////////////


        public dvec2 dot(dvec2 b)
        {
            return dot(this, b);
        }
        public static dvec2 dot(dvec2 a, dvec2 b)
        {
            return a * b;
        }

        public dvec2 cross()
        {
            return cross(this);
        }
        public static dvec2 cross(dvec2 a)
        {
            return new dvec2(a.y, a.x);
        }


        public static dvec2 operator *(dvec2 a, dvec2 b)
        {
            return new dvec2(a.x * b.x, a.y * b.y);
        }
        public static dvec2 operator /(dvec2 a, dvec2 b)
        {
            return new dvec2(a.x / b.x, a.y / b.y);
        }
        public static dvec2 operator +(dvec2 a, dvec2 b)
        {
            return new dvec2(a.x + b.x, a.y + b.y);
        }
        public static dvec2 operator -(dvec2 a, dvec2 b)
        {
            return new dvec2(a.x - b.x, a.y - b.y);
        }



        public static dvec2 operator *(dvec2 a, double b)
        {
            return new dvec2(a.x * b, a.y * b);
        }
        public static dvec2 operator /(dvec2 a, double b)
        {
            return new dvec2(a.x / b, a.y / b);
        }
        public static dvec2 operator +(dvec2 a, double b)
        {
            return new dvec2(a.x + b, a.y + b);
        }
        public static dvec2 operator -(dvec2 a, double b)
        {
            return new dvec2(a.x - b, a.y - b);
        }



        public static dvec2 operator *(double b, dvec2 a)
        {
            return new dvec2(a.x * b, a.y * b);
        }
        public static dvec2 operator /(double b, dvec2 a)
        {
            return new dvec2(a.x / b, a.y / b);
        }
        public static dvec2 operator +(double b, dvec2 a)
        {
            return new dvec2(a.x + b, a.y + b);
        }
        public static dvec2 operator -(double b, dvec2 a)
        {
            return new dvec2(a.x - b, a.y - b);
        }
        public static dvec2 operator -(dvec2 a)
        {
            return new dvec2(-a.x, -a.y);
        }


        public static dvec2 operator *(dvec2 a, fmat2 b)
        {
            return new dvec2((a.x * b.getValue(0, 0)) + (a.y * b.getValue(0, 1)),
                                (a.x * b.getValue(1, 0)) + (a.y * b.getValue(1, 1)));
        }
        public static dvec2 operator *(fmat2 b, dvec2 a)
        {
            return a * b.transposed;
        }

    }
}
