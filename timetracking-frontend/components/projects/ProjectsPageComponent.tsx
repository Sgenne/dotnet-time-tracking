import { JSXElementConstructor, ReactElement, useState } from "react";
import styles from "../../styles/projects/ProjectsPageComponent.module.css";
import ControlledStateHandler from "../../types/ControlledStateHandler";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import PlusIcon from "../utils/icons/PlusIcon";
import Table from "../utils/Table";
import NewProjectModal from "./NewProjectModal";

const DUMMY_TABLE_ITEMS: { [key: string]: string | ReactElement<any, string | JSXElementConstructor<any>>; }[]
    = [{
        Project: "AG",
        "Time Status": "7h",
        Team: "Simon"
    },
    {
        Project: "Kandidatarbete",
        "Time Status": "141h",
        Team: "Simon"
    },
    {
        Project: "Software Analysis and Design",
        "Time Status": "7h",
        Team: "Simon"
    }]


export interface ProjectPageComponentProps {
    newProjectNameStateHandler: ControlledStateHandler<string>;
    newProjectDescriptionHandler: ControlledStateHandler<string>;
}

const ProjectPageComponent = ({ newProjectNameStateHandler, newProjectDescriptionHandler }: ProjectPageComponentProps) => {
    const [showNewProjectModal, setShowNewProjectModal] = useState(false);

    const newProjectClickHandler = () => setShowNewProjectModal(true);
    const newProjectCloseHandler = () => setShowNewProjectModal(false);

    return (
        <div className={styles["page-container"]}>
            {
                showNewProjectModal ? <NewProjectModal
                    nameStateHandler={newProjectNameStateHandler}
                    descriptionStateHandler={newProjectDescriptionHandler}
                    onClose={newProjectCloseHandler} /> : <></>
            }
            <div className={styles["top-bar"]}>
                <h2>Projects</h2>
                <span className={styles["new-project-button-container"]}>
                    <PrimaryButton onClick={newProjectClickHandler}>
                        <>
                            <PlusIcon />
                            <span className={styles["new-project-button__text"]}>New Project</span>
                        </>
                    </PrimaryButton>
                </span>
            </div>
            <div className={styles["projects-table"]}>
                <Table tableItems={DUMMY_TABLE_ITEMS} />
            </div>
        </div>
    )
}

export default ProjectPageComponent