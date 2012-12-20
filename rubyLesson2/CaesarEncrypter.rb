class CaesarEncrypter
  private 
  @@Z_UPPER_ASCII = 'Z'.ord
  @@Z_LOWER_ASCII = 'z'.ord
    
  public
  def encrypt text, step
    result = ''
    text.each_byte do |ascii|
      encryptedAscii = ascii + step
      if  encryptedAscii > @@Z_LOWER_ASCII || ( encryptedAscii > @@Z_UPPER_ASCII and ascii <= @@Z_UPPER_ASCII)
        result += (encryptedAscii - 26).chr
      else
        result += encryptedAscii.chr
      end
    end
    result
  end 
end