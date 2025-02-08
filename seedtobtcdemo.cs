using System;
using NBitcoin;
using NBitcoin.Crypto;

class Program
{
    static void Main(string[] args)
    {
		
string seedPhrase = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
    var mnemonic = new Mnemonic(seedPhrase, Wordlist.English);
    Console.WriteLine("Seed phrase: " + mnemonic.ToString());
    var rootKey = mnemonic.DeriveExtKey();
    var account = rootKey.Derive(new KeyPath("m/44'/0'/0'"));
    var receiveKeyPath = new KeyPath("0/0");
    var receiveKey = account.Derive(receiveKeyPath).PrivateKey;
    var address = receiveKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main).ToString();
    var privateKey = receiveKey.GetWif(Network.Main).ToString();
    Console.WriteLine("Bitcoin address: " + address);
    Console.WriteLine("Private key: " + privateKey);	
    }
}
 
