using System.Security.Cryptography;

namespace HashCalculator;

// 实现：.NET（System.Security.Cryptography）
internal class Sha256 : BclHash
{
    public override int DigestLength => 32;

    public override string AlgoName => "SHA-256";

    public override AlgoType AlgoType => AlgoType.SHA_256;

    public override IHashAlgoInfo NewInstance()
    {
        return new Sha256();
    }

    public Sha256() : base(SHA256.Create()) { }
}
