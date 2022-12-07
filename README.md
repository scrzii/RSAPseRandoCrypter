# RSAPseRandoCrypter
Cryptographer library. Based on RSA and BlumBlumShub crypto-resistant pseudo-random generator

Main class is Crypter (RSAPseRandoCrypter assembly).
Using:
1. Key generating: call GenerateKeys method from Crypter instance. You will get keypair with SecretKey and OpenKey. Keys are strings.
  OpenKey is public key, you can send it publicly
  SecretKey is your private key. It needs for decrypting data.
2. Encryption: call Encrypt method with OpenKey (generated at point 1) and ecryption message (your string which you want encrypting) as parameters. 
You will get ecnrypted string, which you also can send publicly.
3. Decryption: call Decrypt method with secret key (generated at point 1) and encrypted message. Your will get an original message.

All string data is stored in hexadecimal byte format
If you use .dll reference add <EnablePreviewFeatures>true</EnablePreviewFeatures> to .csproj file
