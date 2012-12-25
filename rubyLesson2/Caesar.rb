def encrypt text
  result = ''
  text.each_byte do |ascii|
    if (ascii <= 'Z'.ord && ascii > 90-3) || (ascii > 122-3)
        result += ((ascii + 3) -26).chr
    else 
        result += (ascii + 3).chr
    end
  end
  result
end

puts encrypt 'Za'