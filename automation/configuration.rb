module Automation
  class Configuration < Thor
    namespace :configuration
		
		desc 'copy', 'copies config files to artifacts'
		def copy
			invoke 'automation:init'

      settings.config_files.each do |file|
        [settings.artifacts_dir, settings.app_dir, settings.web.staging_dir].each do|folder|
            FileUtils.cp(file, folder)
          end
      end
		end

  end
end
