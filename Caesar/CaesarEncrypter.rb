class CaesarEncrypter
  public
  def encrypt text, step
    result = ''
    text.each_byte do |ascii|
      encryptedAscii = ascii + step
      if  encryptedAscii > 'z'.ord || ( encryptedAscii > 'Z'.ord and ascii <= 'Z'.ord)
        result += (encryptedAscii - 26).chr
      else
        result += encryptedAscii.chr
      end
    end
    result
  end 
end