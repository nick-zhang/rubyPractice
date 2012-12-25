class CaesarEncrypter
  private 
  @@Z_UPPER_ASCII = 'Z'.ord
  @@Z_LOWER_ASCII = 'z'.ord
  ENCRYPT_CODE = 3
    
  public
  def encrypt text
    result = ''
    text.each_byte do |ascii|
      encryptedAscii = ascii + ENCRYPT_CODE
      if (isAsciiOutOfLetters  ascii)
        result += (encryptedAscii - 26).chr
      else
        result += encryptedAscii.chr
      end
    end
    result
  end 
  
  private 
  def isAsciiOutOfLetters ascii
    ascii > @@Z_LOWER_ASCII - ENCRYPT_CODE || ( ascii > @@Z_UPPER_ASCII - ENCRYPT_CODE &&  ascii <= @@Z_UPPER_ASCII)
  end
end