﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Interfaces;

namespace Vectors.Core
{
    /// <summary>
    /// A double-precision floating point, 2x2 (4 element) matrix.
    /// </summary>
    public class dmat2 : idmat2
    {
        ///////////////////////////
        //        Values         //
        ///////////////////////////

        public double[] data { get; protected set; } = new double[4];

        public virtual int rowCount { get { return 2; } }
        public virtual int columnCount { get { return 2; } }

        ///////////////////////////
        //     Constructors      //
        ///////////////////////////

        public dmat2()
        {
        }
        public dmat2(dmat2 template)
        {
            Array.Copy(template.data, data, data.Length);
        }

        ///////////////////////////
        //      Generators       //
        ///////////////////////////

        public static dmat2 identity()
        {
            dmat2 output = new dmat2();
            for (int i = 0; i < output.rowCount && i < output.columnCount; i++)
                output.setValue(i, i, 1);
            return output;
        }
        public static dmat2 rotate(double angle)
        {
            throw new NotImplementedException();
        }

        ///////////////////////////
        //      Conversions      //
        ///////////////////////////

        //todo: check if this causes a transpose
        public static dmat2 fromNestedVector(tvec2<tvec2<double>> input)
        {
            dmat4 output = new dmat4();

            output.setValue(0, 0, input.x.x);
            output.setValue(0, 1, input.x.y);

            output.setValue(1, 0, input.y.x);
            output.setValue(1, 1, input.y.y);

            return output;
        }

        ///////////////////////////
        //      Accessors        //
        ///////////////////////////

        //todo: check rows and columns aren't being swapped (transposed)
        public double getValue(int row, int column)
        {
            //Design decision: we should be able to pass around a mat2 in a mat3
            // reference and simply use the columns that are present.

            if (row >= rowCount || column >= columnCount || row < 0 || column < 0)
                return 0;
            return data[(row * columnCount) + column];
        }

        //todo: check rows and columns aren't being swapped (transposed)
        public void setValue(int row, int column, double value)
        {
            //Design decision: writing to a matrix out of its bounds
            // should fail. This is so that if you're passing around a
            // mat2 in a mat3 reference, it shouldn't silently fail
            // when you try to write to a slot that doesn't exist.
            // This is an asymmetry between get and set which might
            // not be obvious.

            if (row >= rowCount || column >= columnCount || row < 0 || column < 0)
                throw new IndexOutOfRangeException();
            data[(row * columnCount) + column] = value;
        }

        ///////////////////////////
        //      Transforms       //
        ///////////////////////////

        public idmat2 transposed
        {
            get
            {
                return transposedRaw;
            }
        }
        public dmat2 transposedRaw
        {
            get
            {
                dmat2 output = new dmat2();
                for (int x = 0; x < rowCount; x++)
                    for (int y = 0; y < columnCount; y++)
                        output.setValue(x, y, getValue(y, x));
                return output;
            }
        }

        ///////////////////////////
        //       Mutators        //
        ///////////////////////////

        public virtual void transpose()
        {
            assign(transposed);
        }

        public void assign(idmat2 other)
        {
            for (int i = 0; i < other.data.Length && i < data.Length; i++)
                data[i] = other.data[i];
        }

        ///////////////////////////
        //       Operators       //
        ///////////////////////////


        public double this[int i] { get { return data[i]; } set { data[i] = value; } }

    }
}