﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestionsProject;

namespace FPA_Tools_User_Interface.Project.Questions
{
    class Questions
    {
        ProjectQuestions _project = new ProjectQuestions();

        public UserControl getProject() {
            return _project;
        }


    }
}