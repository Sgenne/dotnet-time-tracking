import ProjectPageComponent from "../components/projects/ProjectsPageComponent"
import withAuthentication from "../higherOrderComponents/WithAuthentication"
import useStringInput from "../hooks/useStringInput"
import ControlledStateHandler from "../types/ControlledStateHandler"

const Projects = () => {
    const newProjectNameStateHandler: ControlledStateHandler<string> =
        useStringInput();
    const newProjectDescriptionStateHandler: ControlledStateHandler<string> =
        useStringInput();

    return <ProjectPageComponent
        newProjectNameStateHandler={newProjectNameStateHandler}
        newProjectDescriptionHandler={newProjectDescriptionStateHandler} />
}

export default withAuthentication(Projects)