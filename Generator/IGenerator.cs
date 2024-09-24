

namespace Generators
{
    public interface IGeneratorBiNas
    {
    }

    public interface IGenerator : IGeneratorBiNas
    {
        public string Generate();
    }

    public interface IGenerator<T> : IGeneratorBiNas
    {
        public string Generate(T arg);
    }

    public interface IGenerator<T, U> : IGeneratorBiNas
    {
        public string Generate(T arg1, U arg2);
    }

    public interface IGenerator<T, U, V> : IGeneratorBiNas
    {
        public string Generate(T arg1, U arg2, V arg3);
    }
}
