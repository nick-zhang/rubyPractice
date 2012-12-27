def meet names, &action
    names.each &action
    action.call("you")
end

meet ["Nick", "Carry"] do |name|
  puts "Hello #{name}"
end