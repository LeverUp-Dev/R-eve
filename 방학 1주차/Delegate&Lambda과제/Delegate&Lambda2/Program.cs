namespace Test
{
    //함수와 동일하게 리턴값이 있을경우 그에 맞춰 타입을 바꿔주고
    //입력값이 필요한 경우 함수와 돌일하게 리턴 값을 넣어주면 된다
    //public delegate void TestDelegateA();
    public delegate int TestDelegateA(int a, int b);

    internal class Program
    {
        //public delegate void TestDelegateB();
        public delegate int TestDelegateB(int a, int b);
        //public delegate void TestDelegateC();
        public delegate int TestDelegateC(int a, int b);

        private static void Main(string[] args)
        {
            //델리게이트 함수는 메인 함수 내부에서 사용불가능
            TestDelegateA delegateA = TestMethod;//델리게이트 1번째 초기화 방식
            TestDelegateB delegateB = delegate (int a, int b) { return a + b; };//델리게이트 2번째 초기화 방식
            TestDelegateC delegateC = (a, b) => { return a + b; };//람다식 초기화 방식

            //호출 방법은 일반적인 함수 호출과 동일
            delegateA(10, 6);
            delegateB(7, 6);
            delegateC(5, 4);
        }

        private static int TestMethod(int a, int b)
        {
            return a + b;
        }
    }
}