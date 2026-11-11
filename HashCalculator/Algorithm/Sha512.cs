using System.Security.Cryptography;

namespace HashCalculator;

// 实现：.NET（System.Security.Cryptography）
internal class Sha512 : BclHash
{
    public override int DigestLength => 64;

    public override string AlgoName => "SHA-512";

    public override AlgoType AlgoType => AlgoType.SHA_512;

    public override IHashAlgoInfo NewInstance()
    {
        return new Sha512();
    }

    public Sha512() : base(SHA512.Create()) { }
}
