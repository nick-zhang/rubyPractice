class CaesarEncrypter
  public
  def encrypt text, step
    result = ''
    z_upper_ord = 'Z'.ord 
    z_lower_ord = 'z'.ord
    text.each_byte do |ascii|
      encryptedAscii = ascii + step
      if  encryptedAscii > z_lower_ord || ( encryptedAscii > z_upper_ord and ascii <= z_upper_ord)
        result += (encryptedAscii - 26).chr
      else
        result += encryptedAscii.chr
      end
    end
    result
  end 
end