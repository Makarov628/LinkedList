using System;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PostfixExpressionTests
    {
        [Test]
        public void PostfixSimple()
        {
            var stack = new MultiTypeStack();
            stack.Push('+');
            stack.Push(3);
            stack.Push(3);

            Assert.That(PostfixExpression.Postfix(stack), Is.EqualTo(6));
            Assert.That(PostfixExpression.MathOperation(3, '+', 3), Is.EqualTo(6));
        }

        [Test]
        public void PostfixMultiplyAndAddition()
        {
            var stack = new MultiTypeStack();
            stack.Push('+');
            stack.Push(9);
            stack.Push('*');
            stack.Push(5);
            stack.Push('+');
            stack.Push(2);
            stack.Push(8);

            Assert.That(
                PostfixExpression.MathOperation(9, '+',
                    PostfixExpression.MathOperation(5, '*',
                        PostfixExpression.MathOperation(2, '+', 8)
                    )
                ),
                Is.EqualTo(59));

            Assert.That(PostfixExpression.Postfix(stack), Is.EqualTo(59));
        }

        [Test]
        public void PostfixDivide()
        {
            var stack = new MultiTypeStack();
            stack.Push('/');
            stack.Push(2);
            stack.Push('/');
            stack.Push(2);
            stack.Push('/');
            stack.Push(2);
            stack.Push(8);

            Assert.That(
                PostfixExpression.MathOperation(2, '/',
                    PostfixExpression.MathOperation(2, '/',
                        PostfixExpression.MathOperation(2, '/', 8)
                    )
                ),
                Is.EqualTo(1));

            Assert.That(PostfixExpression.Postfix(stack), Is.EqualTo(1));
        }

        [Test]
        public void PostfixSubsctraction()
        {
            var stack = new MultiTypeStack();
            stack.Push('-');
            stack.Push(1);
            stack.Push('-');
            stack.Push(3);
            stack.Push('-');
            stack.Push(4);
            stack.Push(8);

            Assert.That(
                PostfixExpression.MathOperation(1, '-',
                    PostfixExpression.MathOperation(3, '-',
                        PostfixExpression.MathOperation(4, '-', 8)
                    )
                ),
                Is.EqualTo(0));

            Assert.That(PostfixExpression.Postfix(stack), Is.EqualTo(0));
        }

        [Test]
        public void PostfixStringAsOperation()
        {
            var stack = new MultiTypeStack();
            stack.Push("Unknown Operation");
            stack.Push(1);
            stack.Push("Unknown Operation");
            stack.Push(3);
            stack.Push('-');
            stack.Push(4);
            stack.Push(8);

            Assert.That(PostfixExpression.Postfix(stack), Is.EqualTo(3));
        }


        [Test]
        public void PostfixUnknownOperation()
        {
            var stack = new MultiTypeStack();
            stack.Push('-');
            stack.Push(1);
            stack.Push('q');
            stack.Push(3);
            stack.Push('-');
            stack.Push(4);
            stack.Push(10);

            Assert.That(
                PostfixExpression.MathOperation(1, '-',
                    PostfixExpression.MathOperation(3, 'q',
                        PostfixExpression.MathOperation(4, '-', 10)
                    )
                ),
                Is.EqualTo(-1));

            Assert.That(PostfixExpression.Postfix(stack), Is.EqualTo(-1));
        }

    }
}
