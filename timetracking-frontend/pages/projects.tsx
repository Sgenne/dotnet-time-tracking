import NewProjectModal from "../components/projects/NewProjectModal"
import ProjectPageComponent from "../components/projects/ProjectPageComponent"
import withAuthentication from "../higherOrderComponents/WithAuthentication"
import useStringInput from "../hooks/useStringInput"
import ControlledStateHandler from "../types/ControlledStateHandler"

const Projects = () => {
    const newProjectNameStateHandler: ControlledStateHandler<string> =
        useStringInput();
    const newProjectDescriptionStateHandler: ControlledStateHandler<string> =
        useStringInput();

    return <>
        <NewProjectModal
            nameStateHandler={newProjectNameStateHandler}
            descriptionStateHandler={newProjectDescriptionStateHandler} />
        <ProjectPageComponent />
    </>
}

export default withAuthentication(Projects)