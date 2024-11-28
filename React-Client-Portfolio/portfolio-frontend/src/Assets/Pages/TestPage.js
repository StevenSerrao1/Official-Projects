import HeaderComponent from "../../Components/RealComponents/Header/HeaderComponent";
import GetTest from "../../Components/TestComponents/GetTest";
import PostTest from "../../Components/TestComponents/PostTest";

function TestPage()
{
    return(
        <div>
            <HeaderComponent />
            <GetTest />
            <PostTest />
        </div>
    );
}

export default TestPage;