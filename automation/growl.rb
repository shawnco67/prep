module Automation
  class Growl < Thor
    namespace :growl

    desc 'start', 'starts the growl runner'
    def start
      system("start automation/tools/growl/Growl.exe")
    end
  end
end
