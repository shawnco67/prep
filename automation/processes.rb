module Automation
  class Processes < Thor
    namespace :processes

    desc 'kill_runner_processes', 'kill all the runner processes'
    def kill_runner_processes
      kill(*settings.runner_processes)
    end

    desc 'kill', 'kills a process'
    def kill(*processes)
      processes.each do |process|
        command = "get-process -Name #{process} | stop-process"
        system("start powershell -WindowStyle hidden -Command \"#{command}\"")
      end
    end
  end
end
