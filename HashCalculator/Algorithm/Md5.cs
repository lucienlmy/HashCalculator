using System.Security.Cryptography;

namespace HashCalculator;

// 实现：.NET（System.Security.Cryptography）
internal class Md5 : BclHash
{
    public override int DigestLength => 16;

    public override string AlgoName => "MD5";

    public override AlgoType AlgoType => AlgoType.MD5;

    public override IHashAlgoInfo NewInstance()
    {
        return new Md5();
    }

    public Md5() : base(MD5.Create()) { }
}
