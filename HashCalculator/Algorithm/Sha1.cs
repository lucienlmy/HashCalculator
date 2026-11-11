using System.Security.Cryptography;

namespace HashCalculator;

// 实现：.NET（System.Security.Cryptography）
internal class Sha1 : BclHash
{
    public override int DigestLength => 20;

    public override string AlgoName => "SHA-1";

    public override AlgoType AlgoType => AlgoType.SHA_1;

    public override IHashAlgoInfo NewInstance()
    {
        return new Sha1();
    }

    public Sha1() : base(SHA1.Create()) { }
}
