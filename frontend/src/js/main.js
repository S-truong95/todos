import Header from "./components/Header";
import Footer from "./components/Footer";
import Todos from "./components/Todos";
import apiActions from "./api/apiActions";
import Home from "./components/Home";

export default () =>{
    pageBuild(); 
};

function pageBuild(){
    header();
    footer();
    navHome();
    navTodos();
}

function header(){
    const header = document.getElementById("header");
    header.innerHTML = Header();
}

function footer(){
    const footer = document.getElementById("footer");
    footer.innerHTML = Footer();
}

function navHome(){
    const homeButton = document.querySelector(".nav_home")
    homeButton.addEventListener("click", function(){
        document.querySelector("#app").innerHTML = Home();
    })
}

function navTodos(){
    const toDosButton = document.querySelector(".nav_toDos");
    
    toDosButton.addEventListener("click", function(){
        apiActions.getRequest("https://localhost:44385/api/todos", toDos => {
            document.querySelector("#app").innerHTML = Todos(toDos);
        });
    });

}
