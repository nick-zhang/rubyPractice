def printStars(repeatTimes)
  i = 0
  while i < repeatTimes do 
    print "*"
    i=i+1
  end
  print "\n"
end

def printStarsNew(rTimes)
  if rTimes == 1
    puts "*" 
    return
  end
  
  printStarsNew(rTimes -1) if rTimes > 1
  
  1.upto(rTimes) do |i|
    print "*"
  end
  
  print "\n"
  
end

printStarsNew(3)
