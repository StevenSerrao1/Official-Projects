import React, {JSX} from 'react';
import { Project} from './types/interfaces';
import "../../../Assets/Fonts/LemonMilkRegularFont.css"

// Below is one of two recommended ways to CREATE A TYPESCRIPT FUNCTIONAL COMPONENT
const ExpandProject = (props: Project): JSX.Element => {
    return <div className="expanded-card text-wrap">
            <div className="container text-center">
                <div className="row mb-3">
                    <div className="col d-flex justify-content-center">
                        <p className="lm-reg-font plain-yellow-underline">{props.title}</p>
                    </div>
                </div>
                <div className="row mb-2">
                    <div className="w-100" style={{wordBreak: "break-word", whiteSpace: "normal"}}>
                        <p className="lm-reg-font plain-yellow-underline">
                            {props.fullDescription}
                        </p>
                    </div>
                </div>
            </div>
    </div>;
}

export default ExpandProject;