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
  
  i = 0
  while i < rTimes do 
    print "*"
    i=i+1
  end
  print "\n"
  
  printStarsNew(rTimes -1) 

end

printStarsNew(3)

 